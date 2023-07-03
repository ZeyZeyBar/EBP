using EBP.Core.Service;
using EBP.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBP.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class AdminController : Controller
    {
        private readonly ICoreService<PersonelUser> _personelUser;
        private readonly ICoreService<Personel> _personel;
        private readonly ICoreService<Department> _department;
        private readonly ICoreService<Brand> _brand;

        public AdminController(ICoreService<PersonelUser> personelUser, ICoreService<Personel> personel,ICoreService<Department> department,ICoreService<Brand> brand)
        {
            _brand = brand;
            _personelUser = personelUser;
            _personel = personel;
            _department = department;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
