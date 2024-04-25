using System.Text.Json.Serialization;

namespace DiziSinema.MVC.Areas.Admin.Models.Genre
{
    public class DeletedGenreViewModel
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
