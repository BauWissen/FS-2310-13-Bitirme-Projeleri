using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.SerialTv
{
    public class DeletedSerialTvViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }


        [JsonPropertyName("SerName")]
        public string SerName { get; set; }


        [JsonPropertyName("Serlanguage")]
        public string Serlanguage { get; set; }


        [JsonPropertyName("IsDeleted")]
        public bool IsDeleted { get; set; }


        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }


        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
