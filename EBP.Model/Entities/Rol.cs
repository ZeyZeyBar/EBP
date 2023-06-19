using EBP.Core.Entity;
using System.Collections.Generic;

namespace EBP.Model.Entities
{
    public class Rol:CoreEntity
    {
        public string RolName{ get; set; }
        public ICollection<User> Users { get; set; }
    }
}
