using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.DAL.Models;

namespace Transactions.BLL.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetAsync(int id);
		Task AddAsync(T entity);
		void Delete(T entity);
		void Update(T entity);
	}
}
