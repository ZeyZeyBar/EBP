using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public IActionResult BrandList()
        {
            return View(_brandDb.GetAllRecords());
        }

        public IActionResult BrandAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BrandAdd(Brand brand) 
        {
            if (brand.BrandName != null)
            {
                return _brandDb.Add(brand) ? View("BrandList", _brandDb.GetAllRecords()) : View();
            }

            ViewBag.BrandAddError = "Malzeme Tipi Adını Boş Geçemezsiniz";
            return View();
        }

        public IActionResult BrandUpdate(int id)
        {
            return View(_brandDb.GetById(id));
        }

        [HttpPost]
        public IActionResult BrandUpdate(Brand brand)
        {
            if (brand.BrandName != null)
            {
                return _brandDb.Update(brand) ? View("BrandList", _brandDb.GetAllRecords()) : View();
            }
            ViewBag.BrandUpdateError = "Malzeme Tipi Adını Giriniz.";
            return View();
        }
        public IActionResult BrandDelete(int id)
        {
            return _brandDb.Delete(id) ? View("BrandList", _brandDb.GetAllRecords()) : View();
        }

        public IActionResult PersonelList()
        {
            var personelList=_personelDb.GetAllRecords();
            List<PersonelListDto> personelListDtos = new List<PersonelListDto>();
            foreach (var item in personelList)
            {
                var personels=new PersonelListDto();
                var department = _departmentDb.GetById(item.DepartmentID);
                if (item.DepartmentID==department.ID)
                {
                    personels.ID = item.ID;
                    personels.RegisterNo = item.RegisterNo;
                    personels.PersonelName = item.PersonelName;
                    personels.PersonelLastName = item.PersonelLastName;
                    personels.DepartmentNAME = department.DepartmentName;
                    personels.PersonelAddress = item.PersonelAddress;
                    personels.PersonelBirthDay = item.PersonelBirthDay;
                    personelListDtos.Add(personels);
                }                
            }  
            return View(personelListDtos);
        }
        public IActionResult PersonelAdd()
        {
            var newPersonel = new PersonelListDto()
            {
               Department=_departmentDb.GetAllRecords()
            };
            return View(newPersonel);
        }

        [HttpPost]
        public IActionResult PersonelAdd(PersonelListDto personel)
        {
            if(personel.PersonelName != null && personel.PersonelLastName!=null)
            {
                var newPersonel = new Personel()
                {
                    RegisterNo = personel.RegisterNo,
                    PersonelName = personel.PersonelName,
                    PersonelLastName = personel.PersonelLastName,
                    PersonelAddress = personel.PersonelAddress,
                    PersonelBirthDay = personel.PersonelBirthDay,
                    DepartmentID = _departmentDb.GetRecord(x => x.ID == personel.DepartmentID).ID
                };
               return _personelDb.Add(newPersonel) ? RedirectToAction("PersonelList") : View();
            }
            return View();
        }

        public IActionResult PersonelUpdate(int id)
        {
            var personel=_personelDb.GetById(id);
            if(personel != null)
            {
                var record = new PersonelListDto()
                {
                    ID= id,
                    RegisterNo = personel.RegisterNo,
                    PersonelName = personel.PersonelName,
                    PersonelLastName = personel.PersonelLastName,
                    PersonelAddress = personel.PersonelAddress,
                    PersonelBirthDay = personel.PersonelBirthDay,
                    DepartmentID = _departmentDb.GetById(personel.DepartmentID).ID,
                    Department=_departmentDb.GetAllRecords(),
                    DepartmentNAME=_departmentDb.GetRecord(x=>x.ID==personel.DepartmentID).DepartmentName
                    
                };
                return View(record);
            }
            ViewBag.PersonelError = "Güncellenecek kaydınız bulunamadı.";
            return View();
        }

        [HttpPost]
        public IActionResult PersonelUpdate(PersonelListDto personel)
        {
            var record = _personelDb.GetById(personel.ID);
            if (record!=null)
            {
                record.ID = personel.ID;
                record.RegisterNo = personel.RegisterNo;
                record.PersonelName = personel.PersonelName;
                record.PersonelLastName = personel.PersonelLastName;
                record.PersonelBirthDay = personel.PersonelBirthDay;
                record.PersonelAddress = personel.PersonelAddress;
                record.DepartmentID = _departmentDb.GetRecord(x => x.ID == personel.DepartmentID).ID;
                
                return _personelDb.Update(record) ? RedirectToAction("PersonelList") : View();
            }
            return View();
        }

        public IActionResult PersonelDelete(int id)
        {
            return _personelDb.Delete(id) ? RedirectToAction("PersonelList") : View();
        }

        public IActionResult UserList()
        {
            var personelList = _userDb.GetAllRecords();
            List<RolDto> personelListDtos = new List<RolDto>();
         
            foreach (var item in personelList)
            {
                var personels = new RolDto();
                var user = _personelDb.GetById(item.PersonelID);
              
                if (item.PersonelID == user.ID)
                {
                    personels.ID = item.ID;                    
                    personels.UserName = item.UserName;
                    personels.LastName = item.UserLastName;
                    personels.PersonelID = item.PersonelID;
                    personels.PersonelFullName = user.PersonelName + " " + user.PersonelLastName;
                    personels.RolTypes = item.RolType;
                    personelListDtos.Add(personels);
                }
            }
            return View(personelListDtos);
        }
        public IActionResult UserAdd()
        {
            var newPersonel = new RolDto()
            {
                Personels = _personelDb.GetAllRecords()
            };
            return View(newPersonel);
        }
        [HttpPost]
        public IActionResult UserAdd(RolDto rolDto)
        {
            if (rolDto.UserName != null && rolDto.LastName != null)
            {
                var newPersonel = new PersonelUser()
                {
                    UserName= rolDto.UserName,
                    UserLastName= rolDto.LastName,
                    RolType=rolDto.RolTypes,
                    PersonelID= _personelDb.GetRecord(x => x.ID == rolDto.PersonelID).ID
                };
                return _userDb.Add(newPersonel) ? RedirectToAction("UserList") : View();
            }
            return View();
        }
        public IActionResult UserUpdate(int id)
        {
            var personel = _userDb.GetById(id);
            if (personel != null)
            {
                var record = new RolDto()
                {
                    ID = id,
                    UserName = personel.UserName,
                    LastName=personel.UserLastName,
                    RolTypes=personel.RolType,              
                    Personels=_personelDb.GetAllRecords(),
                    PersonelID = _personelDb.GetById(personel.PersonelID).ID,
                    PersonelFullName = _personelDb.GetRecord(x => x.ID == personel.PersonelID).PersonelName + " " + _personelDb.GetRecord(x => x.ID == personel.PersonelID).PersonelLastName
                };
                return View(record);
            }
            ViewBag.UserError = "Güncellenecek kaydınız bulunamadı.";
            return View();
        }

        [HttpPost]
        public IActionResult UserUpdate(RolDto personel)
        {
            var record = _userDb.GetById(personel.ID);
            if (record != null)
            {
                record.ID = personel.ID;
                record.UserName = personel.UserName;
                record.UserLastName = personel.LastName;
                record.RolType = personel.RolTypes;               
                record.PersonelID = _personelDb.GetRecord(x => x.ID == personel.PersonelID).ID;

                return _userDb.Update(record) ? RedirectToAction("UserList") : View();
            }
            return View();
        }
        public IActionResult UserDelete(int id)
        {
            return _userDb.Delete(id) ? RedirectToAction("UserList") : View();
        }
    }


}
