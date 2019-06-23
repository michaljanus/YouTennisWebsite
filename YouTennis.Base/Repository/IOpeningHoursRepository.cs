using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;

namespace YouTennis.Base.Repository
{
    public interface IOpeningHoursRepository : IBaseAsync<OpeningHours>
    {
        Task<IEnumerable<OpeningHours>> GetByCourtId(int courtId);
        Task<OpeningHours> GetByCourtIdForDate(int courtId, int day);
    }
}
