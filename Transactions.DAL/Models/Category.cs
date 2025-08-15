using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.DAL.Models
{
	public class Category : BaseEntity
	{
        public string Title { get; set; }
        public string Icon { get; set; }
        public CategoryType Type { get; set; } = CategoryType.Expense;
    }

    public enum CategoryType
    {
		[EnumMember(Value = "Expense")]
		Expense,
		[EnumMember(Value = "Income")]
		Income
    }
}
