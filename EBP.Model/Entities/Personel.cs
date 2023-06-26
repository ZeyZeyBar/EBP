using EBP.Core.Entity;
using System;
using System.Collections.Generic;

namespace EBP.Model.Entities
{
    public class Personel:CoreEntity
    {
        public int RegisterNo { get; set; }
        public string PersonelName { get; set; }
        public string PersonelLastName { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        public DateTime PersonelBirthDay { get; set; }
        public string PersonelAddress { get; set; }
        public ICollection<PersonelUser> Users { get; set; }
    }
}
