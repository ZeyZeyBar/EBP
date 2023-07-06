using EBP.Core.Service;
using EBP.Model.Entities;
using EBP.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EBP.WebUI.Areas.User.Controllers
{
    [Authorize] 
	[Area("User")]
	public class PersonelController : Controller
	{
		private readonly ICoreService<PersonelUser> _userDb;
		private readonly ICoreService<Personel> _personelDb;
		private readonly ICoreService<Department> _departmentDb;
		private readonly ICoreService<Inventory> _inventoryDb;
		private readonly ICoreService<Brand> _brandDb;
        public PersonelController(ICoreService<PersonelUser> userDb, ICoreService<Department> departmentDb,ICoreService<Inventory> inventoryDb,ICoreService<Personel> personelDb, ICoreService<Brand> brandDb)
        {
            _departmentDb = departmentDb;
			_inventoryDb = inventoryDb;
			_userDb = userDb;
			_personelDb = personelDb;
			_brandDb = brandDb;
        }
        public IActionResult Index()
		{
			var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
			var personelId = _userDb.GetById(id);
			var result = _personelDb.GetRecord(x => x.ID == personelId.PersonelID);

			var record = new PersonelDto()
			{
				Name = result.PersonelName,
				Surname = result.PersonelLastName,

			};
			return View(record);
		}
        public IActionResult Brands()
        {
            return View(_brandDb.GetAllRecords());
        }
        public IActionResult PersonelDepartmentInventory()
		{
			var id = int.Parse(User.Claims.FirstOrDefault(c => c.Type.EndsWith("ID")).Value);
            var user = _userDb.GetById(id);
            var personel = _personelDb.GetRecord(x => x.ID == user.PersonelID);
			var result = _inventoryDb.GetAllRecords();
			List<PersonelDepartmentInventoryDto> personelListDtos = new List<PersonelDepartmentInventoryDto>();
            foreach (var item in result)
            {
                var inventory = new PersonelDepartmentInventoryDto();
                var personelInventory = _inventoryDb.GetRecord(x => x.DepartmentID == personel.DepartmentID);
				var datas = _inventoryDb.GetRecord(x => x.DepartmentID == personel.DepartmentID);

                var  brand= _brandDb.GetById(item.BrandID);
                if (item.DepartmentID == personelInventory.DepartmentID)
                {
					inventory.BrandId=item.BrandID;
					inventory.MaterialCode=item.MaterialCode;
					inventory.MaterialTypeName=item.MaterialTypeName;
					inventory.BrandName = brand.BrandName;
					inventory.Count = item.Count;
					inventory.Brands=_brandDb.GetAllRecords();
					inventory.Departments=_departmentDb.GetAllRecords();                
                    personelListDtos.Add(inventory);
                }
            }
            return View(personelListDtos);
        }		
    }
}