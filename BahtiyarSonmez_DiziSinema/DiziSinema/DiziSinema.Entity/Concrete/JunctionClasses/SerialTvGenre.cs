using DiziSinema.Entity.Concrete.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Entity.Concrete.JunctionClasses
{
    public class SerialTvGenre
    {
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int SerialTvId { get; set; }
        public SerialTv SerialTv { get; set; }
    }
}
