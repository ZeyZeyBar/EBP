using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EBP.WebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class ChiefController : Controller
    {
        private readonly ICoreService<PersonelUser> _userDb;
        private readonly ICoreService<Personel> _personelDb;
        private readonly ICoreService<Department> _departmentDb;
        private readonly ICoreService<Inventory> _inventoryDb;
        private readonly ICoreService<Brand> _brandDb;
        public ChiefController(ICoreService<PersonelUser> userDb, ICoreService<Department> departmentDb, ICoreService<Inventory> inventoryDb, ICoreService<Personel> personelDb, ICoreService<Brand> brandDb)
        {
            _userDb = userDb;
            _personelDb = personelDb;
            _departmentDb = departmentDb;
            _inventoryDb = inventoryDb;
            _brandDb = brandDb;
        }
        public IActionResult Index()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(id);
            var result = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);

            var record = new ChiefDto()
            {
                Name = result.PersonelName,
                Surname = result.PersonelLastName,
                DepartmentName = _departmentDb.GetById(result.DepartmentID).DepartmentName
            };
            return View(record);
        }

        public IActionResult PersonelList()
        {
            return View(_personelDb.GetAllRecords());
        }
        public IActionResult InventoryList()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(id);
            var personelInfo = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);
            var query = _inventoryDb.GetAllRecords();
            List<Inventory> inventory = new List<Inventory>();
            foreach (var record in query)
            {
                if (personelInfo.DepartmentID == record.DepartmentID)
                {
                    record.Brands = _brandDb.GetAllRecords();
                    inventory.Add(record);
                }
            }
            return View(inventory);
        }
        public IActionResult InventoryAdd()
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(id);
            var result = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);
            var inventory = _inventoryDb.GetRecord(x => x.DepartmentID == result.DepartmentID);

            var record = new Inventory()
            {
                DepartmentID = result.DepartmentID,
                Brands = _brandDb.GetAllRecords()
            };
            return View(record);
        }
        [HttpPost]
        public IActionResult InventoryAdd(Inventory s, int BrandID)
        {
            var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(id);
            var personelInfo = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);
            var invenrtory = _inventoryDb.GetRecord(x => x.DepartmentID == personelInfo.DepartmentID);

            if (s != null)
            {
                var record = new Inventory()
                {
                    MaterialCode = s.MaterialCode,
                    MaterialTypeName = s.MaterialTypeName,
                    Count = s.Count,
                    DepartmentID = s.DepartmentID,
                    BrandID = BrandID
                };

                return _inventoryDb.Add(record) ? RedirectToAction("InventoryList") : View();
            }

            return View("Index");
        }

        public IActionResult InventoryEdit(int id)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var personelId = _userDb.GetById(userId);
            var personelInfo = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);
            var inventory = _inventoryDb.GetRecord(x => x.ID == id);

            if (inventory != null)
            {
                var record = new Inventory()
                {
                    MaterialTypeName = inventory.MaterialTypeName,
                    MaterialCode = inventory.MaterialCode,
                    Count = inventory.Count,
                    DepartmentID = inventory.DepartmentID,
                    BrandID = inventory.BrandID,
                    Brands = _brandDb.GetAllRecords()
                };

                return View(record);
            }
            ViewBag.InventoryError = "Güncellenecek kaydınız bulunamadı.";
            return View();
        }
        [HttpPost]
        public IActionResult InventoryEdit(Inventory s)
        {
            var record = _inventoryDb.GetRecord(x => x.DepartmentID == s.DepartmentID && x.ID == s.ID);
            if (s != null)
            {
                record.MaterialCode = s.MaterialCode;
                record.MaterialTypeName = s.MaterialTypeName;
                record.Count = s.Count;
                record.BrandID = s.BrandID;

                return _inventoryDb.Update(record) ? RedirectToAction("InventoryList") : View();
            }
            return View();
        }

    //    [HttpDelete]
        public IActionResult InventoryDelete(int id)
        {
            var record = _inventoryDb.GetRecord(x => x.ID == id);
            if (record != null)
            {
                return _inventoryDb.Delete(id) ? RedirectToAction("InventoryList") : View();
            }
            return View();
        }
    }
}
