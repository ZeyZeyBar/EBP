using EBP.Model.Entities;
using System.Collections.Generic;

namespace EBP.WebUI.Areas.User.Models
{
    public class RolDto
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string RolTypes { get; set; }
        public int PersonelID { get; set; }
        public string PersonelFullName { get; set; }
        public List<Personel> Personels { get; set; }
    }
}
