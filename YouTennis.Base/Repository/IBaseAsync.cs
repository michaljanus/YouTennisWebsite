using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Repository
{
    public interface IBaseAsync<T> where T : class, IId, new()
    {
        Task<int> AddAsync(T model);
        Task DeleteAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
