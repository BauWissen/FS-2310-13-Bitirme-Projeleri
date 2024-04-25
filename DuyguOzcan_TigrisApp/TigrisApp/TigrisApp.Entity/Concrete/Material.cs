using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Abstract;

namespace TigrisApp.Entity.Concrete
{
    public class Material :BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}