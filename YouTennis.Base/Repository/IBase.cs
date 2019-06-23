using System.Collections.Generic;
using YouTennis.Base.Model;

namespace YouTennis.Base.Repository
{
    public interface IBase<T> where T : class, IId, new()
    {
        int Add(T model);
        void Delete(T model);
        T Update(T model);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
