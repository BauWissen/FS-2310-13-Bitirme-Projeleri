using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Abstract;

namespace TigrisApp.Entity.Concrete
{
    public class Supplier : BaseEntity , IBaseEntity
    {
       
        public int RegionId { get; set; }
        public string Name { get ; set ; }
    }
}