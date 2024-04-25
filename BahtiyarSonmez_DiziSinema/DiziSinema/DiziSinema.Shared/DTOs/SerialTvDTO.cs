using DiziSinema.Shared.DTOs.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Shared.DTOs
{
    public class SerialTvDTO
    {
        public int Id { get; set; }
        public string SerName { get; set; }
        public string SerIntro { get; set; }
        public string ImageUrl { get; set; }
        public string Serlanguage { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<InGenreDTO> GenreList { get; set; }
    }
}
