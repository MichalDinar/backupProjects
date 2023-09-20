using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> AddAsync(T entity);
        Task<List<T>> UpdateAsync(T entity);
        Task<List<T>> DeleteAsync(int id);

    }
}
