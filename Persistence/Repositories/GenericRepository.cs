using Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
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
    }
}
