using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
				DepartmentName=_departmentDb.GetById(result.DepartmentID).DepartmentName
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
            var personelInfo=_personelDb.GetRecord(x=>x.ID == personelId.PersonelID);
            var query = _inventoryDb.GetAllRecords();
            List<Inventory> inventory = new List<Inventory>();
            foreach (var record in query)
            {
                if (personelInfo.DepartmentID == record.DepartmentID)
                {
                    record.Brands=_brandDb.GetAllRecords();
                    inventory.Add(record); 

                }
            }
            
            return View(inventory);
        }
        public IActionResult InventoryAdd(int departmentId)
        {
            return View(_inventoryDb.GetRecord(x=>x.DepartmentID==departmentId));
        }
    }
}
