using DiziSinema.MVC.Areas.Admin.Models.Genre;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Movie
{
    public class AddMovieViewModel
    {
        [JsonPropertyName("MovName")]
        [DisplayName("Film")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string MovName { get; set; }


        [JsonPropertyName("MovIntro")]
        [DisplayName("Film Özellikleri")]
        public string MovIntro { get; set; }


        [JsonPropertyName("ImageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }


        [JsonPropertyName("Movlanguage")]
        public string Movlanguage { get; set; }


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsActive")]
        [DisplayName("Aktif Filmler")]
        public bool IsActive { get; set; }


        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }


        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }


        [JsonPropertyName("GenreIds")]
        public List<int> GenreIds { get; set; } = new List<int>();


        [DisplayName("Türler")]
        public List<GenreViewModel> GenreList { get; set; }
    }
}
