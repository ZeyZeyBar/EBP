using EBP.Model.Entities;
using EBP.Model.Maps;
using Microsoft.EntityFrameworkCore;

namespace EBP.Model.Context
{
    public class EBPContext:DbContext
    {
        public EBPContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new PersonelMap());
            modelBuilder.ApplyConfiguration(new RolMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Personel> Personels { get; set;}
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
