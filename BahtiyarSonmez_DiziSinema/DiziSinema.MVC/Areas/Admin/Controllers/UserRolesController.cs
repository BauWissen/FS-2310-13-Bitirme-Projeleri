using DiziSinema.MVC.Identity;
using DiziSinema.MVC.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiziSinema.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserRolesController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
           
            var userRoles = await _userManager.GetRolesAsync(user);

            var roles = await _roleManager.Roles.Select(r => new AssignRoleViewModel
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsAssigned = userRoles.Any(x=>x==r.Name),
            }).ToListAsync();


            var userRolesViewModel = new UserRoleViewModel
            {
                Id = user.Id,
                Name =$"{user.FirstName} {user.LastName}",
                UserName = user.UserName,
                Roles = roles,
            };

            return View(userRolesViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AssignRoles(UserRoleViewModel userRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userRoleViewModel.Id);
                foreach (var role in userRoleViewModel.Roles)
                {
                    if (role.IsAssigned)
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName);
                    }
                    else
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(userRoleViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Deleted(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            var userDelet = await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Roles()
        {
            var users = await _roleManager.Roles.ToListAsync();
            return View(users);
        }
    }
}
