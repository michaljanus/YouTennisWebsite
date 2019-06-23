using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Repository
{
    public interface ICourtRepository : IBaseAsync<Court>
    {
        Task<IEnumerable<Court>> GetByClubId(int clubId);
    }
}
