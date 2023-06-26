using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
	public class InventoryMap:CoreMap<Inventory>
	{
		public override void Configure(EntityTypeBuilder<Inventory> builder)
		{
			builder.Property(x => x.MaterialTypeName)
				.HasMaxLength(100)
				.IsRequired(true);
			builder.Property(x=>x.MaterialCode)
				.HasMaxLength(100)
				.IsRequired(true);
			builder.Property(x => x.Count)
				.IsRequired(true);
		}
	}
}
