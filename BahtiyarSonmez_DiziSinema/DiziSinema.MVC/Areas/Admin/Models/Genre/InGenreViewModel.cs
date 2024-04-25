using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Genre
{
    public class InGenreViewModel
    {
        public int Id { get; set; }

        [JsonPropertyName("GenreName")]
        public string GenreName { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }
    }
}
