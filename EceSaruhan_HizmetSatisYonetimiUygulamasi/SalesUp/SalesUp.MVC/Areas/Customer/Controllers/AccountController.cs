using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Entity.Identity;
using SalesUp.MVC.EmailServices.Abstract;
using SalesUp.Shared.ViewModels.IdentityModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesUp.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly INotyfService _notyfService;


     
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrderService orderManager, IEmailSender emailSender, INotyfService notyfService, ISTaskService staskManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notyfService = notyfService;

        }

        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {

                var user = await _userManager.FindByIdAsync(userId);

                UserProfileViewModel userProfileViewModel = new UserProfileViewModel
                {
                    User = new UserViewModel
                    {
                        Id = userId,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Address = user.Address,
                        City = user.City,
                        Gender = user.Gender,
                        DateOfBirth = user.DateofBirth
                    },

                };
                return View(userProfileViewModel);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel userProfileViewModel)
        {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);
             
            
                    user.FirstName = userProfileViewModel.User.FirstName;
                    user.LastName = userProfileViewModel.User.LastName;
                    user.Email = userProfileViewModel.User.Email;
                    user.City = userProfileViewModel.User.City;
                    user.Address = userProfileViewModel.User.Address;
                    user.PhoneNumber = userProfileViewModel.User.PhoneNumber;
                    user.DateofBirth = userProfileViewModel.User.DateOfBirth;
                    user.Gender = userProfileViewModel.User.Gender;
                    user.UserName = userProfileViewModel.User.UserName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, false);
                        _notyfService.Success("Profiliniz başarıyla güncellenmiştir");
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                
                return View(userProfileViewModel);
            }

            return View();

        }

        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
                var isVerified = await _userManager.CheckPasswordAsync(user, changePasswordViewModel.OldPassword);
                if (isVerified)
                {
                    var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
                    if (result.Succeeded)
                    {
                        var updateSecurityStampResult = await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, changePasswordViewModel.NewPassword, false, false);
                        _notyfService.Success("Şifreniz başarıyla değiştirilmiştir.");
                        return RedirectToAction("Profile");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(changePasswordViewModel);
                }
                _notyfService.Warning("Geçerli şifreniz hatalıdır");
            }
            return View(changePasswordViewModel);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                _notyfService.Warning("Bilgilerinizde hata var. Kontrol ediniz.");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _notyfService.Error("Kullanıcı bilgilerinize ulaşılamadı.");
                return View();
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                //Bu kişi onaylı bir user olduğuna göre, bir shoppingcart oluşturuyoruz.
                _notyfService.Information("Hesabınız başarıyla onaylanmıştır.");
                return RedirectToAction("Login");
            }
            _notyfService.Error("Hesabınız onaylanırken bir sorun oluştu, daha sonra tekrar deneyiniz.");
            return View();
        }
    }
}

