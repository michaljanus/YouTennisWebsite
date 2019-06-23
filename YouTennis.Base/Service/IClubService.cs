using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Service
{
    public interface IClubService
    {
        Task<IEnumerable<Club>> GetAll();
        Task<int> Add(Club model);
        Task<Club> Get(int id);
        Task Delete(int id);
        Task<Club> Update(Club model);
    }
}
