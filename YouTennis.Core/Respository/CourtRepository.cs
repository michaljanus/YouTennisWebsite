using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Core.Context;

namespace YouTennis.Core.Respository
{
    public class CourtRepository : BaseAsync<Court>, ICourtRepository
    {
        public CourtRepository(ApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Court>> GetByClubId(int clubId)
        {
            return await DbSet.Where(x => x.ClubId == clubId).ToListAsync().ConfigureAwait(false);
        }
    }
}
