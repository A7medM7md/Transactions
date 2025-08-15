using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.BLL.Interfaces;
using Transactions.BLL.Repositories;
using Transactions.DAL.Data;
using Transactions.DAL.Models;

namespace Transactions.BLL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		private Hashtable _repositories;

		public UnitOfWork(AppDbContext context)
        {
			_context = context;
		}

        public async Task<int> Complete()
			=> await _context.SaveChangesAsync();
		public ValueTask DisposeAsync()
		=> _context.DisposeAsync();
		public IGenericRepository<TRepo> GetRepository<TRepo>() where TRepo : BaseEntity
		{
			var type = typeof(TRepo).Name;

			if (_repositories.ContainsKey(type))
			{
				var repository = new GenericRepository<TRepo>(_context);
				_repositories.Add(type, repository);
			}

			return (IGenericRepository<TRepo>)_repositories[type];
		}
	}
}
