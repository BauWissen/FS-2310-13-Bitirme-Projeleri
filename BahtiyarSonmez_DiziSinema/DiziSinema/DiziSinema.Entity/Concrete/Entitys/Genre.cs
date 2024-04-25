using DiziSinema.Entity.Absratct;
using DiziSinema.Entity.Concrete.JunctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Entity.Concrete.Entitys
{
    public class Genre:BaseEntity
    {
        public string GenreName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<SerialTvGenre> SerialTvGenres { get; set; }
    }
}
