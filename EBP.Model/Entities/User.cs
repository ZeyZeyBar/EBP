using EBP.Core.Entity;
using System.Collections.Generic;

namespace EBP.Model.Entities
{

    public class User:CoreEntity
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string RolType { get; set; }
        public int PersonelID { get;set; }
        public Personel Personel { get; set; }
      
    }
}
