using Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TikilazapeeDbContext _context;
        private readonly DbSet<T> _dbSet;
        private IDbContextTransaction _transactions;
        public GenericRepository(TikilazapeeDbContext context)
        {
            if(_context == null)
            {
                _context = context;
            }
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }      
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveAsync(T entity)
        {
             _dbSet.Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task BeginTransactionAsync()
        {
            if(_transactions == null)
            {
                _transactions = await _context.Database.BeginTransactionAsync(); 
            }
        }
        public async Task CommitTransactionAsync()
        {
            if( _transactions != null)
            {
                await _transactions.CommitAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if(_transactions != null)
            {
                await _transactions.RollbackAsync();

            }
        }
        
    }
}
