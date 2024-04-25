using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigrisApp.Entity.Concrete
{
    public class ProductGender 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product? Product { get; set; }
        
        public int GenderId { get; set; }

        public Gender? Gender { get; set; }
        

    }
}