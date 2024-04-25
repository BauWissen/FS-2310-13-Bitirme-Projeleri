using DiziSinema.MVC.Areas.Admin.Models.Genre;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Models.SerialTvViewModels
{
    public class SerialTvDetailViewModel
    {
        public int Id { get; set; }


        [JsonPropertyName("SerName")]
        [DisplayName("Dizi")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string SerName { get; set; }


        [JsonPropertyName("SerIntro")]
        [DisplayName("Dizi Özellikleri")]
        public string SerIntro { get; set; }


        [JsonPropertyName("ImageUrl")]
        [DisplayName("Resim")]
        public string ImageUrl { get; set; }


        [JsonPropertyName("Serlanguage")]
        public string Serlanguage { get; set; }


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsActive")]
        [DisplayName("Aktif dizi")]
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
