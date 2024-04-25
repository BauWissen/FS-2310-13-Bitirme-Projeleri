using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models
{
    public class Response<T>
    {
        [JsonPropertyName("Data")]
        public T Data { get; set; }

        [JsonPropertyName("Errors")]
        public object Errors { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }
    }
}
