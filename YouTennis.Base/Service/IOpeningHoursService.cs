using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Service
{
    public interface IOpeningHoursService
    {
        Task<IEnumerable<OpeningHours>> GetAll();
        Task<int> Add(OpeningHours model);
        Task<OpeningHours> Get(int id);
        Task Delete(int id);
        Task<OpeningHours> Update(OpeningHours model);
    }
}

