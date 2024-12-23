using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(string id);
        public Task AddAsync(T entity);
        public void UpdateAsync(T entity);
        public void RemoveAsync(T entity);

    }
}
