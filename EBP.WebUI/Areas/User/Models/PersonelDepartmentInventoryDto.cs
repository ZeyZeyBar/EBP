using EBP.Model.Entities;
using System.Collections.Generic;

namespace EBP.WebUI.Areas.User.Models
{
    public class PersonelDepartmentInventoryDto
    {
        public int PersonelId { get; set; }
        public int DepartmentId { get; set; }
        public int BrandId { get; set; }
        public string MaterialTypeName { get; set; }
        public string MaterialCode { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Personel> Personels { get; set; }
        public List<Department> Departments { get; set; }
    }
}