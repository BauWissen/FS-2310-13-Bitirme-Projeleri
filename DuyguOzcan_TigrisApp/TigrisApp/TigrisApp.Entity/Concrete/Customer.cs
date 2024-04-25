using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigrisApp.Entity.Abstract;
using TigrisApp.Entity.Concrete.Identity;

namespace TigrisApp.Entity.Concrete
{
    public class Customer : BaseEntity
    {
       
       public string? AppUserId { get; set; }
       public AppUser? AppUser { get; set; }
       
    }
}