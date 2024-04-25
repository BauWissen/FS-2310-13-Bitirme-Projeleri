using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Movie
{
    public class DeletedMovieViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }


        [JsonPropertyName("MovName")]
        public string MovName { get; set; }


        [JsonPropertyName("Movlaguage")]
        public string Movlanguage { get; set; }


        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }


        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
