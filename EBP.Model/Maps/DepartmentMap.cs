using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
    public class DepartmentMap:CoreMap<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.DepartmentName)
                .HasMaxLength(100)
                .IsRequired(true);
        }
    }
}
