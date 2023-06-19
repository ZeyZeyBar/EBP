using EBP.Core.Entity;
using System.Collections.Generic;

namespace EBP.Model.Entities
{

    public class User:CoreEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RolID { get; set; }
        public Rol Rol { get; set; }
        public int PersonelID { get;set; }
        public Personel Personel { get; set; }
      
    }
}
