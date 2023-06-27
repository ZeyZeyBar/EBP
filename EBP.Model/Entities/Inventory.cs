using EBP.Core.Entity;
using System.Collections.Generic;

namespace EBP.Model.Entities
{
	public class Inventory:CoreEntity
	{
        public string  MaterialTypeName { get; set; }
        public string MaterialCode { get; set; }
        public int Count { get; set; }
        public int DepartmentID { get; set; }
        public int BrandID{ get; set; }
        public List<Brand> Brands { get; set; }
        public List<Department> Departments { get; set; }
    }
}
