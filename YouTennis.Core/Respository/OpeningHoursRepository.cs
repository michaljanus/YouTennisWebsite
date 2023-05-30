using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Core.Context;

namespace YouTennis.Core.Respository
{
    public class OpeningHoursRepository : BaseAsync<OpeningHours>, IOpeningHoursRepository
    {
        public OpeningHoursRepository(ApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OpeningHours>> GetByCourtId(int courtId)
        {
            return await DbSet.Where(x => x.CourtId == courtId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<OpeningHours> GetByCourtIdForDate(int courtId, int day)
        {
            return await DbSet.Where(x => x.CourtId == courtId && x.DayId == day).SingleOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
