using EBP.Model.Entities;
using System.Collections.Generic;
using System;

namespace EBP.WebUI.Areas.User.Models
{
    public class PersonelListDto
    {
        public int ID { get; set; }
        public int RegisterNo { get; set; }
        public string PersonelName { get; set; }
        public string PersonelLastName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentNAME { get; set; }
        public List<Department> Department { get; set; }

        public DateTime PersonelBirthDay { get; set; }
        public string PersonelAddress { get; set; }
        public List<Personel> Users { get; set; }
    }
}
