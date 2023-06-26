using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
    public class UserMap :CoreMap<PersonelUser>
    {
        public override void Configure(EntityTypeBuilder<PersonelUser> builder)
        {
            builder.Property(x => x.UserName)
                .HasMaxLength(100)
                .IsRequired(true);
            builder.Property(x=>x.UserLastName)
                .HasMaxLength (100)
                .IsRequired(true);
            builder.Property(x => x.RolType)
             .HasMaxLength(100)
             .IsRequired(true);
        }
    }
}
