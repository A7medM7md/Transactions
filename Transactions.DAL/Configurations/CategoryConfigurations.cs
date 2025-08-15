using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.DAL.Models;

namespace Transactions.DAL.Configurations
{
	public class CategoryConfigurations : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(C => C.Title).HasColumnType("nvarchar(50)");
			builder.Property(C => C.Icon).HasColumnType("nvarchar(5)");
			builder.Property(C => C.Type).HasColumnType("nvarchar(10)");

			builder.Property(C => C.Type)
				.HasConversion(
					categoryType => categoryType.ToString(),
					categoryTypeDb => (CategoryType)Enum.Parse(typeof(CategoryType), categoryTypeDb)
				);
		}
	}
}
