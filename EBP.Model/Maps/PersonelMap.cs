using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
    public class PersonelMap:CoreMap<Personel>
    {
        public override void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.Property(x => x.RegisterNo)
                .IsRequired(true);
            builder.Property(x=>x.PersonelName)
                .HasMaxLength(150)
                .IsRequired(true);
            builder.Property(x=>x.PersonelLastName)
                .HasMaxLength(150)
                .IsRequired(true);
            builder.Property(x=>x.PersonelAddress)
                .HasMaxLength(150)
                .IsRequired(false);
            builder.Property(x => x.PersonelBirthDay)
                .IsRequired(true);
        }
    }
}
