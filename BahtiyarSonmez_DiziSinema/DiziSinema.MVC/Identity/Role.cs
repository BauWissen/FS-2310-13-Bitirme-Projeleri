using Microsoft.AspNetCore.Identity;

namespace DiziSinema.MVC.Identity
{
    public class Role:IdentityRole
    {
        public string Description { get; set; }
    }
}
