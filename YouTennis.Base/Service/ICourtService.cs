using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Service
{
    public interface ICourtService
    {
        Task<IEnumerable<Court>> GetAll();
        Task<int> Add(Court model);
        Task<Court> Get(int id);
        Task Delete(int id);
        Task<Court> Update(Court model);
        Task<IEnumerable<Court>> GetByClubId(int clubId);
    }
}
