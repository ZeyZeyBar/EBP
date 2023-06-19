using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EBP.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> _userDb;
        private readonly ICoreService<Rol> _rolDb;
        private readonly ICoreService<Personel> _personelDb;

        public AccountController( ICoreService<User> userDb,ICoreService<Rol> rolDb,ICoreService<Personel> personelDb)
        {
            _userDb = userDb;
            _rolDb = rolDb;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (lvm.LoginType == 1) //user
            {
                var result = _userDb.GetRecord(x => x.UserName == lvm.Name && x.Password == lvm.Password);
                if (result != null)
                {
                    // claims(talepler)
                    var claims = new List<Claim>()
                    {
                        new Claim("ID", result.ID.ToString()),
                        new Claim("LoginType", lvm.LoginType.ToString()),
                        new Claim(ClaimTypes.Name, result.UserName),

                       // new Claim(ClaimTypes., result.Password)
                    };


                    var user = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(user);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "BasicUser", new { area = "User" });
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
