using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EBP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<PersonelUser> _userDb;
        private readonly ICoreService<Personel> _personelDb;

        public AccountController( ICoreService<PersonelUser> userDb,ICoreService<Personel> personelDb)
        {
            _userDb = userDb;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (lvm.LoginType == 1) //personel user
            {
                var result = _userDb.GetRecord(x => x.UserName == lvm.Name && x.UserLastName == lvm.Surname);
                if (result != null)
                {
                    // claims(talepler)
                    var claims = new List<Claim>()
                    {
                        new Claim("ID", result.ID.ToString()),
                        new Claim("LoginType", lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Name, result.UserName),

                        new Claim(ClaimTypes.Surname, result.UserLastName),
                        new Claim(ClaimTypes.Role,result.RolType)
                    };


                    var user = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(user);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Personel", new { area = "User" });
                }
            }
            else if (lvm.LoginType == 2)//chief
            {
                var result = _userDb.GetRecord(x => x.UserName == lvm.Name && x.UserLastName == lvm.Surname);
                if (result != null)
                {
                    // claims(talepler)
                    var claims = new List<Claim>()
                    {
                        new Claim("ID", result.ID.ToString()),
                        new Claim("LoginType", lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Name, result.UserName),

                        new Claim(ClaimTypes.Surname, result.UserLastName),
                        new Claim(ClaimTypes.Role,result.RolType)
                    };


                    var user = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(user);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Chief", new { area = "User" });
                }
            }
            else if (lvm.LoginType == 3)//admin
            {
                var result = _userDb.GetRecord(x => x.UserName == lvm.Name && x.UserLastName == lvm.Surname);
                if (result != null)
                {
                    // claims(talepler)
                    var claims = new List<Claim>()
                    {
                        new Claim("ID", result.ID.ToString()),
                        new Claim("LoginType", lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Name, result.UserName),

                        new Claim(ClaimTypes.Surname, result.UserLastName),
                        new Claim(ClaimTypes.Role,result.RolType)
                    };


                    var user = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(user);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Admin", new { area = "User" });
                }
            }
            else
            {
                TempData["LoginMessage"] = "Kullanıcı bilgileriniz sistemde tanımlı değildir. Gerekli Kontrolü sağlanıyınız.";
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
