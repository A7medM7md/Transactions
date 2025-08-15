using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.DAL.Models
{
	public class Transaction : BaseEntity
	{
        public decimal Amount { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
