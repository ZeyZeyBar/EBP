using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EBP.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class AdminController : Controller
    {
        private readonly ICoreService<PersonelUser> _userDb;
        private readonly ICoreService<Personel> _personelDb;
        private readonly ICoreService<Department> _departmentDb;
        private readonly ICoreService<Brand> _brandDb;

        public AdminController(ICoreService<PersonelUser> userDb, ICoreService<Personel> personelDb,ICoreService<Department> departmentDb,ICoreService<Brand> brandDb)
        {
            _userDb = userDb;
            _personelDb = personelDb;
            _departmentDb = departmentDb;
            _brandDb = brandDb;
        }
        public IActionResult Index()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(id);
            var result = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);

            var record = new AdminDto()
            {
                Name = result.PersonelName,
                Surname = result.PersonelLastName,
                DepartmentName = _departmentDb.GetById(result.DepartmentID).DepartmentName
            };
            return View(record);
        }

        public IActionResult DepartmantList() 
        { 
            return View(_departmentDb.GetAllRecords());
        }

        public IActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmentAdd(Department department)
        {
            if (department.DepartmentName != null)
            {
                return _departmentDb.Add(department) ? View("DepartmantList", _departmentDb.GetAllRecords()) : View();
            }

            ViewBag.DepartmentAddError = "Departman Adını Boş Geçemezsiniz";
            return View();
        }

        public IActionResult DepartmentUpdate(int id)
        {
            return View(_departmentDb.GetById(id));
        }

        [HttpPost]
        public IActionResult DepartmentUpdate(Department department)
        {
            if(department.DepartmentName != null)
            {
                return _departmentDb.Update(department) ? View("DepartmantList", _departmentDb.GetAllRecords()) : View();
            }
            ViewBag.DepartmentUpdateError = "Departman Adını Giriniz.";
            return View();
        }
        public IActionResult DepartmentDelete(int id)
        {
            return _departmentDb.Delete(id) ? View("DepartmantList", _departmentDb.GetAllRecords()) : View();
        }
    }
}
