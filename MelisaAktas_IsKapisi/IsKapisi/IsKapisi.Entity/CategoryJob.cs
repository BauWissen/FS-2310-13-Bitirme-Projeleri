using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Entity
{
    public class CategoryJob {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       

        public Job Job { get; set; }
        public int JobId { get; set; }

    }
}
