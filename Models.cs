using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

public class APIPathPlannerRequest
{
    [JsonProperty("robot")]
    public Robot Robot { get; set; }

    [JsonProperty("headlandDistance")]
    public double HeadlandDistance { get; set; } = 0.0;

    [JsonProperty("decomposeAngle")]
    public double DecomposeAngle { get; set; } = 0.0;

    [JsonProperty("swath")]
    public SwathGenerator Swath { get; set; }

    [JsonProperty("route")]
    public RouteGenerator Route { get; set; }

    [JsonProperty("geometry")]
    public MultiPolygonGeoJson Geometry { get; set; }
}

public class Robot
{
    [JsonProperty("width")]
    public double Width { get; set; }

    [JsonProperty("coverageWidth")]
    public double CoverageWidth { get; set; }

    [JsonProperty("minTurnRadius")]
    public double MinTurnRadius { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum SwathGeneratorType
{
    NSwath,
    SwathLength,
    Angle
}

public class SwathGenerator
{
    [JsonProperty("type")]
    public SwathGeneratorType Type { get; set; }

    [JsonProperty("angle")]
    public double Angle { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum RouteGeneratorType
{
    Advanced,
    Boustrophedon,
    Snake,
    Spiral
}

public class RouteGenerator
{
    [JsonProperty("type")]
    public RouteGeneratorType Type { get; set; }

    [JsonProperty("startPoint")]
    public int StartPoint { get; set; }

    [JsonProperty("spirals")]
    public int Spirals { get; set; }

    [JsonProperty("minWPDistance")]
    public double MinWPDistance { get; set; }
}

public class MultiPolygonGeoJson
{
    [JsonProperty("type")]
    public string Type { get; set; } = "MultiPolygon";

    [JsonProperty("coordinates")]
    public List<List<List<List<double>>>> Coordinates { get; set; } = new List<List<List<List<double>>>>();
}

public class APIStatusResponse
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("endpoints")]
    public Dictionary<string, string> Endpoints { get; set; } = new Dictionary<string, string>();
}

public class PathPlannerResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("length")]
    public double Length { get; set; }

    [JsonProperty("path")]
    public LineString Path { get; set; }
}

public class LineString
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("coordinates")]
    public List<List<double>> Coordinates { get; set; }
}
