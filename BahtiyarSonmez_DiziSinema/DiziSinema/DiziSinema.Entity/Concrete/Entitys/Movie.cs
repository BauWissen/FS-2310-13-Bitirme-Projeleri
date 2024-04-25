using DiziSinema.Entity.Absratct;
using DiziSinema.Entity.Concrete.JunctionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Entity.Concrete.Entitys
{
    public class Movie:BaseEntity
    {
        public string MovName { get; set; }
        public string MovIntro { get; set; }
        public string MovLanguage { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
