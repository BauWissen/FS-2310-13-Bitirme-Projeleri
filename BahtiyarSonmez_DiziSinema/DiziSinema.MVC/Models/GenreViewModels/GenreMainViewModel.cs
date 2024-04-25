using DiziSinema.MVC.Areas.Admin.Models.Genre;
using DiziSinema.MVC.Models.MovieViewModels;
using DiziSinema.MVC.Models.SerialTvViewModels;
using DiziSinema.MVC.ViewComponents;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Models.GenreViewModels
{
    public class GenreMainViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }


        [JsonPropertyName("GenreName")]
        public string GenreName { get; set; }


        [JsonPropertyName("Description")]
        public string Description { get; set; }


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }


        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }


        [JsonPropertyName("SerialTvList")]
        public List<SerialTvMainViewModel> SerialTvList { get; set; }


        [JsonPropertyName("MovieList")]
        public List<MovieMainViewModel> MovieList { get; set; }
    }
}
