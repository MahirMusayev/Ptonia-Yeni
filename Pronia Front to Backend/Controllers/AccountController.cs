using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia_Front_to_Backend.Models;
using Pronia_Front_to_Backend.ViewModels.Account;

namespace Pronia_Front_to_Backend.Controllers
{
    public class AccountController(UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            AppUser user = new AppUser
            {
                Email = vm.Email,
                Name = vm.Name,
                Surname = vm.Surname,
                UserName = vm.UserName,

            };
            IdentityResult result = await _userManager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var eror in result.Errors)
                {
                    ModelState.AddModelError("", eror.Description);
                    return View(vm);
                }
            }

            return RedirectToAction(nameof(Index),"Home");
        }
    }
}








