using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Entity
{
    public class Job
    {
       

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDelete { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; } //url kısmındaki isimi tutmak için
        public string Properties { get; set; }
        public bool IsHome { get; set; } 
        public string ImageUrl { get; set; }

      


        public List<CategoryJob> CategoryJobs { get; set; }

    }
}
