using Microsoft.AspNetCore.Identity;

namespace CosmeticShop.Entity.Concrete.Identity
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}
