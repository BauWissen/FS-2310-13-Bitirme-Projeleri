using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesUp.Entity.Identity;

namespace SalesUp.MVC.Areas.Admin.Controllers;

[Authorize(Roles = "SuperAdmin, Admin")]
[Area("Admin")]
public class RoleController : Controller
{
    private readonly UserManager<Entity.Identity.User> _userManager;

    private readonly RoleManager<Role> _roleManager;
    // GET
    public RoleController(UserManager<Entity.Identity.User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _roleManager.Roles.ToListAsync());
    }
}