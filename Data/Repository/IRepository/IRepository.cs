using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false);
        Task AddAsync(T entity);
        void Remove (T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
