using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Abstract;

namespace TeamTask.Entity.Concrete
{
    public class Status:BaseEntity
    {
        public string Color { get; set; }
        public string DisplayText { get; set; }
      

    }
}
