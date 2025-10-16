using System.Text.Json.Serialization;

namespace API.Models
{
    public class EpisodeResponse
    {
        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("results")]
        public List<Episode> Results { get; set; }
    }
}
