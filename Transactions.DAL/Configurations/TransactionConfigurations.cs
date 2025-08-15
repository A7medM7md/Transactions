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
	public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(EntityTypeBuilder<Transaction> builder)
		{
			builder.Property(T => T.Note).HasColumnType("nvarchar(75)");	
			builder.Property(T => T.Amount).HasColumnType("decimal(18,3)");	
		}
	}
}
