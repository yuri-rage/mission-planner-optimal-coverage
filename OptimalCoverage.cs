using MissionPlanner;
using MissionPlanner.Controls;
using MissionPlanner.Plugin;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using static MAVLink;
using System.Net;
using System.Threading.Tasks;

namespace OptimalCoverage
{
    public class OptimalCoverage : Plugin
    {
        public override string Name => "Optimal Coverage";
        public override string Version => "v0.1.0-alpha";
        public override string Author => "Yuri Rage";

        private string api_host = "127.0.0.1";
        private string api_port = "8087";
        private string api_url = "";
        private bool APIHealthy = false;
        private OptimalCoverageUI form;
        private MyDataGridView commands;
        private Dictionary<int, mavlink_mission_item_int_t> fencepoints;

        //[DebuggerHidden]
        public override bool Init()
        {
            loopratehz = 1;
            return true;
        }

        public override bool Loop()
        {
            UpdateFencePoints(); // ugly hack to poach fences from UI while user is editing them
            return true;
        }

        public override bool Loaded()
        {
            // waypoint/fence grid on FlightPlanner GCS view
            commands = Host.MainForm.FlightPlanner.Controls.Find("Commands", true).FirstOrDefault() as MyDataGridView;
            form = new OptimalCoverageUI { Text = $"{Name} {Version}" };
            form.btn_Submit.Click += SubmitClick;
            form.btn_Refresh.Click += RefreshClick;
            LoadSetting("OC_SwathWidth", form.num_SwathWidth);
            LoadSetting("OC_Margin", form.num_Margin);
            LoadSetting("OC_Altitude", form.num_Altitude);
            LoadSetting("OC_ArcSegmentLength", form.num_ArcSegmentLength);
            LoadSetting("OC_MinTurnRadius", form.num_MinTurnRadius);
            LoadSetting("OC_MinWPDistance", form.num_MinWPDistance);
            LoadSetting("OC_DecomposeAngle", form.num_DecomposeAngle);
            LoadSetting("OC_SwathAngle", form.num_SwathAngle);
            LoadSetting("OC_SpiralNum", form.num_Spiral);
            LoadSetting("OC_NSwath", form.rb_NSwath);
            LoadSetting("OC_SwathLength", form.rb_SwathLength);
            LoadSetting("OC_UseSwathAngle", form.rb_SwathAngle);
            LoadSetting("OC_AdvancedRoute", form.rb_AdvancedRoute);
            LoadSetting("OC_Boustrophedon", form.rb_Boustrophedon);
            LoadSetting("OC_Snake", form.rb_Snake);
            LoadSetting("OC_UseSpiral", form.rb_Spiral);
            LoadSetting("OC_UseFences", form.chk_UseFences);
            LoadSetting("OC_StartPoint", form.num_StartPoint);
            if (Host.config.ContainsKey("OC_API_Host")) { api_host = Host.config["OC_API_Host"].ToString(); }
            if (Host.config.ContainsKey("OC_API_Port")) { api_port = Host.config["OC_API_Port"].ToString(); }
            api_url = GetURL(api_host, api_port);
            form.FormClosing += Form_FormClosing;

            var contextMenuItem = new ToolStripMenuItem("Optimal Coverage");
            contextMenuItem.Click += (sender, e) =>
            {
                ShowForm(sender, e);
            };

            if (Host.FPMenuMap.Items.Cast<ToolStripItem>()
                .FirstOrDefault(item => item.Text == "Auto WP") is ToolStripMenuItem autoWPMenu)
            {
                autoWPMenu.DropDownItems.Insert(0, contextMenuItem);
            }
            else
            {
                int insertIndex = Math.Min(3, Host.FPMenuMap.Items.Count);
                Host.FPMenuMap.Items.Insert(insertIndex, contextMenuItem);
            }

            return true;
        }

        public override bool Exit()
        {
            return true;
        }

        public void ShowForm(object sender, EventArgs e)
        {
            form.lbl_Status.Text = "";
            if (!APIHealthy)
            {
                form.lbl_Status.Text = "Awaiting API server status...";
                form.btn_Submit.Enabled = false;
                _ = CheckAPIStatus(); // async fire/forget
            }
            form.ShowDialog();
        }

        public void SubmitClick(object sender, EventArgs e)
        {
            var cmb_missiontype = Host.MainForm.FlightPlanner.Controls.Find("cmb_missiontype", true).FirstOrDefault() as ComboBox;
            switch (cmb_missiontype.Text)
            {
                case "MISSION":
                    break;
                case "FENCE":
                case "RALLY":
                    form.lbl_Status.Text = $"Path planning unavailable in {cmb_missiontype.Text} mode.";
                    return;
                default:
                    form.lbl_Status.Text = $"Unknown mission type: {cmb_missiontype.Text}";
                    // continue trying to plan path
                    break;
            }
            if (!APIHealthy) { form.lbl_Status.Text = "Still awaiting API server status..."; return; }
            form.btn_Submit.Enabled = false;
            _ = PlanPath().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    form.lbl_Status.Text = $"Error planning path: {t.Exception?.Message}";
                    form.btn_Submit.Enabled = true;
                }
                else
                {
                    form.btn_Submit.Enabled = true;
                }
            });
        }

        public void RefreshClick(object sender, EventArgs e)
        {
            string host = api_host;
            string port = api_port;
            var answer = InputBox.Show("Optimal Coverage Config", "API Host or IP:", ref host);
            if (answer == DialogResult.Cancel) return;
            answer = InputBox.Show("Optimal Coverage Config", "API Port:", ref port);
            if (answer == DialogResult.Cancel) return;
            form.lbl_Status.Text = "Checking API status...";
            form.btn_Submit.Enabled = false;
            api_host = host.Trim();
            api_port = port.Trim();
            api_url = GetURL(api_host, api_port);
            _ = CheckAPIStatus(); // async fire/forget
        }

        private async Task CheckAPIStatus()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var response = await client.DownloadStringTaskAsync(api_url);
                    var statusResponse = JsonConvert.DeserializeObject<APIStatusResponse>(response);
                    if (statusResponse?.Status == "success")
                    {
                        form.lbl_Status.Text = $"{statusResponse.Name} : Online";
                        form.btn_Submit.Enabled = true;
                        APIHealthy = true;
                    }
                    else
                    {
                        form.lbl_Status.Text = "API Error";
                        form.btn_Submit.Enabled = false;
                        APIHealthy = false;
                    }
                }
            }
            catch (Exception ex)
            {
                form.lbl_Status.Text = $"API Status Error: {ex.Message}";
            }
        }

        public async Task PlanPath()
        {
            // convert user polygon to UTM
            var drawnPolygon = new List<PointLatLngAlt>();
            Host.FPDrawnPolygon.Points.ForEach(p => drawnPolygon.Add(p));

            // simply do nothing if no valid polygon is drawn
            if (drawnPolygon.Count < 3) { form.lbl_Status.Text = "Invalid polygon."; return; }

            var utmZone = -1; // default invalid zone

            var drawnPolygonUTM = GeodeticPolygonToUTM(drawnPolygon, ref utmZone);

            var exclusionFencesUTM = new List<List<utmpos>>();

            if (form.chk_UseFences.Checked)
            {
                exclusionFencesUTM = FencesToPolygonsUTM(
                    GetExclusionFences(),
                    utmZone,
                    (double)form.num_ArcSegmentLength.Value);
            }

            var robot = new Robot
            {
                // use the same value for both width and coverage width
                // TODO: use separate values for more refined path planning?
                Width = (double)form.num_SwathWidth.Value,
                CoverageWidth = (double)form.num_SwathWidth.Value,
                MinTurnRadius = (double)form.num_MinTurnRadius.Value
            };

            var swath = new SwathGenerator
            {
                Type = form.rb_SwathAngle.Checked ? SwathGeneratorType.Angle :
                       form.rb_NSwath.Checked ? SwathGeneratorType.NSwath :
                       SwathGeneratorType.SwathLength,
                Angle = (double)form.num_SwathAngle.Value,
            };

            var route = new RouteGenerator
            {
                Type = form.rb_Boustrophedon.Checked ? RouteGeneratorType.Boustrophedon :
                       form.rb_Snake.Checked ? RouteGeneratorType.Snake :
                       form.rb_Spiral.Checked ? RouteGeneratorType.Spiral :
                       RouteGeneratorType.Advanced,
                Spirals = (int)form.num_Spiral.Value,
                StartPoint = (int)form.num_StartPoint.Value,
                MinWPDistance = (double)form.num_MinWPDistance.Value,
            };

            var geometry = SerializeMissionGeometry(drawnPolygonUTM, exclusionFencesUTM);

            var headlandDistance = (double)form.num_Margin.Value;
            var decomposeAngle = (double)form.num_DecomposeAngle.Value;

            var request = new APIPathPlannerRequest
            {
                Robot = robot,
                HeadlandDistance = headlandDistance,
                DecomposeAngle = decomposeAngle,
                Swath = swath,
                Route = route,
                Geometry = geometry
            };

            // serialize to JSON
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //var json = JsonSerializer.Serialize(request, options);
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(request, settings);
            Console.WriteLine(json);

            form.lbl_Status.Text = "Planning path...";
            using (var client = new WebClient())
            {
                try
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var response = await client.UploadStringTaskAsync(api_url + "plan-path", "POST", json);

                    var pathResponse = JsonConvert.DeserializeObject<PathPlannerResponse>(response);
                    if (pathResponse == null)
                    {
                        form.lbl_Status.Text = "Error: Invalid response from path planner";
                        return;
                    }

                    if (pathResponse.Status != "success")
                    {
                        form.lbl_Status.Text = $"Error: Path planner returned status '{pathResponse.Status}'";
                        return;
                    }

                    if (pathResponse.Path?.Type != "LineString" || pathResponse.Path?.Coordinates == null)
                    {
                        form.lbl_Status.Text = "Error: Invalid path data in response";
                        return;
                    }

                    Console.WriteLine($"Optimal Coverage: Received {pathResponse.Path.Coordinates.Count} waypoints.");
                    var waypoints = pathResponse.Path.Coordinates
                        .Select(coord => new utmpos(coord[0], coord[1], utmZone).ToLLA())
                        .ToList();
                    WriteWaypointMission(waypoints);
                    form.lbl_Status.Text = $"Received {pathResponse.Path.Coordinates.Count} waypoints ({pathResponse.Length:F1}m)";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Path planner error: {ex.Message}");
                    form.lbl_Status.Text = $"Path planner error: {ex.Message}";
                }
            }
        }

        private void WriteWaypointMission(List<PointLatLngAlt> waypoints)
        {
            commands.Rows.Clear();
            waypoints.ForEach(wp =>
            {
                int idx = commands.Rows.Add();
                commands.Rows[idx].Cells[0].Value = "WAYPOINT";
                commands.Rows[idx].Cells[5].Value = wp.Lat.ToString();
                commands.Rows[idx].Cells[6].Value = wp.Lng.ToString();
                // use altitude from form rather than value passed from path planner
                commands.Rows[idx].Cells[7].Value = form.num_Altitude.Value.ToString();
            });
            // redraw the map
            Host.MainForm.FlightPlanner.writeKML();
        }

        private void UpdateFencePoints()
        {
            // no need to try and poach fences from the UI if a vehicle is connected and has fences onboard
            if (MainV2.comPort.MAV.fencepoints.Count > 0 || commands.Rows.Count == 0)
            {
                return;
            }

            // if the first item isn't a fence, ignore all
            if (!commands.Rows[0].Cells[0].Value.ToString().StartsWith("FENCE"))
            {
                return;
            }

            fencepoints = new Dictionary<int, mavlink_mission_item_int_t>();

            foreach (DataGridViewRow cmd in commands.Rows)
            {
                if (Enum.TryParse<MAV_CMD>(cmd.Cells[0].Value.ToString(), out var parsedCommand) &&
                    float.TryParse(cmd.Cells[1].Value?.ToString(), out float param1) &&
                    float.TryParse(cmd.Cells[2].Value?.ToString(), out float param2) &&
                    float.TryParse(cmd.Cells[3].Value?.ToString(), out float param3) &&
                    float.TryParse(cmd.Cells[4].Value?.ToString(), out float param4) &&
                    double.TryParse(cmd.Cells[5].Value?.ToString(), out double lat) &&
                    double.TryParse(cmd.Cells[6].Value?.ToString(), out double lng) &&
                    double.TryParse(cmd.Cells[7].Value?.ToString(), out double alt))
                {
                    var item = new mavlink_mission_item_int_t()
                    {
                        command = (ushort)parsedCommand,
                        param1 = param1,
                        param2 = param2,
                        param3 = param3,
                        param4 = param4,
                        x = (int)(lat * 1e7),
                        y = (int)(lng * 1e7),
                        z = (int)(alt * 1e7),
                    };
                    fencepoints.Add(fencepoints.Count, item);
                }
            }
        }

        private List<IEnumerable<KeyValuePair<int, mavlink_mission_item_int_t>>> GetExclusionFences()
        {
            if (fencepoints == null || MainV2.comPort.MAV.fencepoints.Count > 0)
            {
                fencepoints = new Dictionary<int, mavlink_mission_item_int_t>(MainV2.comPort.MAV.fencepoints);
            }

            // filter all but exclusion fences
            var exclusionFences = fencepoints
                .Where(a =>
                    a.Value.command == (ushort)MAV_CMD.FENCE_POLYGON_VERTEX_EXCLUSION ||
                    a.Value.command == (ushort)MAV_CMD.FENCE_CIRCLE_EXCLUSION)
                .ChunkByField((a, b, count) =>
                {
                    // circles stand alone
                    if (a.Value.command == (ushort)MAV_CMD.FENCE_CIRCLE_EXCLUSION)
                        return false;

                    // param1 stores expected vertex count
                    if (count >= b.Value.param1)
                        return false;

                    return a.Value.command == b.Value.command;
                })
                .ToList();

            return exclusionFences;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void LoadSetting(string key, Control item)
        {
            if (Host.config.ContainsKey(key))
            {
                if (item is NumericUpDown ud)
                {
                    ud.Value = decimal.Parse(Host.config[key].ToString());
                }
                else if (item is ComboBox cb)
                {
                    cb.Text = Host.config[key].ToString();
                }
                else if (item is CheckBox chk)
                {
                    chk.Checked = bool.Parse(Host.config[key].ToString());
                }
                else if (item is RadioButton rb)
                {
                    rb.Checked = bool.Parse(Host.config[key].ToString());
                }
            }
        }

        private void SaveSettings()
        {
            Host.config["OC_SwathWidth"] = form.num_SwathWidth.Value.ToString();
            Host.config["OC_Margin"] = form.num_Margin.Value.ToString();
            Host.config["OC_Altitude"] = form.num_Altitude.Value.ToString();
            Host.config["OC_ArcSegmentLength"] = form.num_ArcSegmentLength.Value.ToString();
            Host.config["OC_MinTurnRadius"] = form.num_MinTurnRadius.Value.ToString();
            Host.config["OC_MinWPDistance"] = form.num_MinWPDistance.Value.ToString();
            Host.config["OC_DecomposeAngle"] = form.num_DecomposeAngle.Value.ToString();
            Host.config["OC_SwathAngle"] = form.num_SwathAngle.Value.ToString();
            Host.config["OC_SpiralNum"] = form.num_Spiral.Value.ToString();
            Host.config["OC_NSwath"] = form.rb_NSwath.Checked.ToString();
            Host.config["OC_SwathLength"] = form.rb_SwathLength.Checked.ToString();
            Host.config["OC_UseSwathAngle"] = form.rb_SwathAngle.Checked.ToString();
            Host.config["OC_AdvancedRoute"] = form.rb_AdvancedRoute.Checked.ToString();
            Host.config["OC_Boustrophedon"] = form.rb_Boustrophedon.Checked.ToString();
            Host.config["OC_Snake"] = form.rb_Snake.Checked.ToString();
            Host.config["OC_UseSpiral"] = form.rb_Spiral.Checked.ToString();
            Host.config["OC_UseFences"] = form.chk_UseFences.Checked.ToString();
            Host.config["OC_StartPoint"] = form.num_StartPoint.Value.ToString();
            Host.config["OC_API_Host"] = api_host;
            Host.config["OC_API_Port"] = api_port;
        }

        //*** UTILITY METHODS ***//

        public static string GetURL(string host, string port)
        {
            string url = $"{host}:{port}/";
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }
            return url;
        }

        /**
         * Serialize mission geometry to JSON
         * 
         * @param {List<utmpos>} polygon
         * @param {List<List<utmpos>>} fences
         * @returns {MultiPolygonGeoJson} - serializable object
         */
        public static MultiPolygonGeoJson SerializeMissionGeometry(List<utmpos> polygon, List<List<utmpos>> fences)
        {
            // serialize drawn polygon and exclusion fences to JSON
            var multiPolygon = new MultiPolygonGeoJson();

            // add drawn polygon if it exists
            if (polygon.Count > 0)
            {
                var drawnCoords = polygon.Select(p => new List<double> { p.x, p.y, 0.0 }).ToList();
                // close the polygon by adding the first point at the end if not already closed
                if (drawnCoords.Count > 2 &&
                    (Math.Abs(drawnCoords[0][0] - drawnCoords[drawnCoords.Count - 1][0]) > 0.001 ||
                     Math.Abs(drawnCoords[0][1] - drawnCoords[drawnCoords.Count - 1][1]) > 0.001))
                {
                    drawnCoords.Add(new List<double> { drawnCoords[0][0], drawnCoords[0][1], 0.0 });
                }
                multiPolygon.Coordinates.Add(new List<List<List<double>>> { drawnCoords });
            }

            // add exclusion fences
            foreach (var fence in fences)
            {
                if (fence.Count > 0)
                {
                    var fenceCoords = fence.Select(p => new List<double> { p.x, p.y, 0.0 }).ToList();
                    // close the polygon by adding the first point at the end if not already closed
                    if (fenceCoords.Count > 2 &&
                        (Math.Abs(fenceCoords[0][0] - fenceCoords[fenceCoords.Count - 1][0]) > 0.001 ||
                         Math.Abs(fenceCoords[0][1] - fenceCoords[fenceCoords.Count - 1][1]) > 0.001))
                    {
                        fenceCoords.Add(new List<double> { fenceCoords[0][0], fenceCoords[0][1], 0.0 });
                    }
                    multiPolygon.Coordinates.Add(new List<List<List<double>>> { fenceCoords });
                }
            }

            return multiPolygon;
        }

        /**
         * Convert exclusion fence collection to UTM polygons
         * 
         * @param {List<IEnumerable<KeyValuePair<int, mavlink_mission_item_int_t>>>} fences
         * @param {int} zone - UTM zone (by reference - modified to zone used for conversion)
         * @param {double} arcSegmentLength - target for min distance between points (m)
         * @returns {List<List<utmpos>>} - nested list of fence polygons
         */
        public static List<List<utmpos>> FencesToPolygonsUTM(
            List<IEnumerable<KeyValuePair<int, mavlink_mission_item_int_t>>> fences,
             int zone, double arcSegmentLength)
        {
            var polygonsUTM = new List<List<utmpos>>();
            foreach (var chunk in fences)
            {
                if (!chunk.Any())
                {
                    continue;
                }

                mavlink_mission_item_int_t firstItem = chunk.First().Value;
                var command = (MAV_CMD)firstItem.command;

                if (zone < 0)
                {
                    var firstPoint = new PointLatLngAlt
                    {
                        Lat = firstItem.x / 1e7,
                        Lng = firstItem.y / 1e7,
                    };
                    zone = firstPoint.GetUTMZone();
                }

                if (command == MAV_CMD.FENCE_CIRCLE_EXCLUSION)
                {
                    // circular fence to polygonal estimate
                    polygonsUTM.Add(CircularExclusionToPolygonUTM(firstItem, zone, arcSegmentLength));
                }
                else if (command == MAV_CMD.FENCE_POLYGON_VERTEX_EXCLUSION)
                {
                    var poly = chunk.Select(kvp => new PointLatLngAlt
                    {
                        Lat = kvp.Value.x / 1e7,
                        Lng = kvp.Value.y / 1e7
                    }).ToList();
                    polygonsUTM.Add(GeodeticPolygonToUTM(poly, ref zone));
                }
            }
            return polygonsUTM;
        }

        /**
         * Convert LLA polygon to UTM coordinates
         * 
         * @param {List<PointLatLngAlt>} polygon
         * @param {int} zone - UTM zone (by reference)
         * @returns {List<utmpos>}
         */
        public static List<utmpos> GeodeticPolygonToUTM(List<PointLatLngAlt> polygon, ref int zone)
        {
            if (polygon == null || polygon.Count < 3) { return new List<utmpos>(); }

            if (zone < 0)
            {
                var firstPoint = new PointLatLngAlt
                {
                    Lat = polygon[0].Lat,
                    Lng = polygon[0].Lng
                };
                zone = firstPoint.GetUTMZone();
            }

            return utmpos.ToList(PointLatLngAlt.ToUTM(zone, polygon), zone);
        }

        /**
         * Convert circular exclusion fence to segmented polygon in UTM
         * 
         * @param {mavlink_mission_item_int_t} fence
         * @param {int} zone - UTM zone
         * @param {double} minSegmentLength - arc segments will be at least this long (m)
         * @returns {List<utmpos>}
         */
        public static List<utmpos> CircularExclusionToPolygonUTM(
            mavlink_mission_item_int_t fence, int zone, double minSegmentLength)
        {
            double radius = fence.param1;
            var center = new PointLatLngAlt { Lat = fence.x / 1e7, Lng = fence.y / 1e7 };
            var result = new List<PointLatLngAlt>();
            int segments = (int)Math.Ceiling(Math.PI * radius * 2.0 / minSegmentLength);
            segments = Math.Max(segments, 6); // make a hexagon, minimum
            for (int i = 0; i < segments; i++)
            {
                double angleDeg = i * (360f / segments);
                var vertex = center.newpos(angleDeg, radius);
                result.Add(vertex);
            }

            return GeodeticPolygonToUTM(result, ref zone);
        }
    }
}