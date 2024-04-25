using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Abstract;

namespace TigrisApp.Entity.Concrete
{
    public class Region : BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
    }
}