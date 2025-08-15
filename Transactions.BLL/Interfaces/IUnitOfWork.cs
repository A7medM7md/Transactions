using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.DAL.Models;

namespace Transactions.BLL.Interfaces
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		public IGenericRepository<TRepo> GetRepository<TRepo>() where TRepo : BaseEntity;

		public Task<int> Complete();
	}
}
