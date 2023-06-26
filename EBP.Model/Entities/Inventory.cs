using EBP.Core.Entity;

namespace EBP.Model.Entities
{
	public class Inventory:CoreEntity
	{
        public string  MaterialTypeName { get; set; }
        public string MaterialCode { get; set; }
        public int Count { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int BrandID{ get; set; }
        public Brand Brand { get; set; }
    }
}
