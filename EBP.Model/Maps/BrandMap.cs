﻿using EBP.Core.Map;
using EBP.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBP.Model.Maps
{
	public class BrandMap:CoreMap<Brand>
	{
		public override void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.Property(x => x.BrandName)
				.HasMaxLength(50)
				.IsRequired(true);
		}
	}
}
