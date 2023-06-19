using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
    public class RolMap:CoreMap<Rol>
    {

        public override void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.Property(x => x.RolName)
                .HasMaxLength(50)
                .IsRequired(true);
        }
    }
}
