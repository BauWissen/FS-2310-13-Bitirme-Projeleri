using DiziSinema.MVC.Areas.Admin.Models.Movie;
using DiziSinema.MVC.Areas.Admin.Models.SerialTv;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Genre
{
    public class GenreViewModel
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


        [DisplayName("Film Türleri")]
        public List<MovieViewModel> MovieList { get; set; }


        [DisplayName("Dizi Türleri")]
        public List<SerialTvViewModel> SerialTvList { get; set; }


    }
}
