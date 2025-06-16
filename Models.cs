using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OptimalCoverage
{
    public class APIPathPlannerRequest
    {
        [JsonPropertyName("robot")]
        public Robot Robot { get; set; }

        [JsonPropertyName("headland-dist")]
        public double HeadlandDistance { get; set; } = 0.0;

        [JsonPropertyName("decompose-angle")]
        public double DecomposeAngle { get; set; } = 0.0;

        [JsonPropertyName("swath")]
        public SwathGenerator Swath { get; set; }

        [JsonPropertyName("route")]
        public RouteGenerator Route { get; set; }

        [JsonPropertyName("geometry")]
        public MultiPolygonGeoJson Geometry { get; set; }
    }

    public class Robot
    {
        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("cov-width")]
        public double CoverageWidth { get; set; }

        [JsonPropertyName("min-turning-radius")]
        public double MinTurnRadius { get; set; }
    }

    public enum SwathGeneratorType
    {
        [JsonPropertyName("n-swath")]
        NSwath,
        [JsonPropertyName("swath-length")]
        SwathLength,
        [JsonPropertyName("angle")]
        Angle
    }

    public class SwathGenerator
    {
        [JsonPropertyName("type")]
        public SwathGeneratorType Type { get; set; }

        [JsonPropertyName("angle")]
        public double Angle { get; set; }
    }

    public enum RouteGeneratorType
    {
        [JsonPropertyName("advanced")]
        Advanced,
        [JsonPropertyName("boustrophedon")]
        Boustrophedon,
        [JsonPropertyName("snake")]
        Snake,
        [JsonPropertyName("spiral")]
        Spiral
    }

    public class RouteGenerator
    {
        [JsonPropertyName("type")]
        public RouteGeneratorType Type { get; set; }

        [JsonPropertyName("startpoint")]
        public int StartPoint { get; set; }

        [JsonPropertyName("spirals")]
        public int Spirals { get; set; }

        [JsonPropertyName("min-wp-distance")]
        public double MinWPDistance { get; set; }
    }

    public class MultiPolygonGeoJson
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "MultiPolygon";

        [JsonPropertyName("coordinates")]
        public List<List<List<List<double>>>> Coordinates { get; set; } = new List<List<List<List<double>>>>();
    }

    public class APIStatusResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("endpoints")]
        public Dictionary<string, string> Endpoints { get; set; } = new Dictionary<string, string>();
    }

    public class PathPlannerResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("path")]
        public LineString Path { get; set; }
    }

    public class LineString
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<List<double>> Coordinates { get; set; }
    }
}