using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Genre
{
    public class AddGenreViewModel
    {
        [JsonPropertyName("GenreName")]
        [DisplayName("Tür")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string GenreName { get; set; }


        [JsonPropertyName("Description")]
        [DisplayName("Acıklama")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        public string Description { get; set; }


        [JsonPropertyName("Url")]
        public string Url { get; set; }


        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }


        [JsonPropertyName("IsActive")]
        [DisplayName("Aktif Türler")]
        public bool IsActive { get; set; }


        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
