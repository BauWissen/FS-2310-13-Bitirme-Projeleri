using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Shared.DTOs.Core.Add
{
    public class AddSerialTvDTO
    {
        public string SerName { get; set; }
        public string SerIntro { get; set; }
        public string ImageUrl { get; set; }
        public string Serlanguage { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int[] GenreIds { get; set; }
    }
}
