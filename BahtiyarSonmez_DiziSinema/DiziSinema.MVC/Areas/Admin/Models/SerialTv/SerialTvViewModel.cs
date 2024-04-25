using DiziSinema.MVC.Areas.Admin.Models.Genre;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.SerialTv
{
    public class SerialTvViewModel
    {
        public int Id { get; set; }


        [JsonPropertyName("SerName")]
        public string SerName { get; set; }


        [JsonPropertyName("SerIntro")]
        public string SerIntro { get; set; }


        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }


        [JsonPropertyName("Serlanguage")]
        public string Serlanguage { get; set; }


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


        [DisplayName("GenreList")]
        public List<InGenreViewModel> GenreList { get; set; }
    }
}
