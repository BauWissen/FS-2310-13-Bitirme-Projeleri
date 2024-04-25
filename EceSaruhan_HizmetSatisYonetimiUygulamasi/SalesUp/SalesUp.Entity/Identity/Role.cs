using Microsoft.AspNetCore.Identity;

namespace SalesUp.Entity.Identity;

public class Role:IdentityRole
{
    public string Description { get; set; }
}