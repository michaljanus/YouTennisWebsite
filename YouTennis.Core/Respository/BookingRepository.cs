using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Core.Context;
using YouTennis.Core.Identity;

namespace YouTennis.Core.Respository
{
    public class BookingRepository : BaseAsync<Booking>, IBookingRepository
    {
        public BookingRepository(ApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetByCourtForDate(int courtId, DateTime date)
        {
            return await DbSet.Where(x => x.CourtId == courtId && x.BookingDate.Date == date.Date).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Booking> GetBookingForSpecificDate(int courtId, DateTime date)
        {
            return await DbSet.Where(x => x.CourtId == courtId && x.BookingDate == date).SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Booking>> GetByUser(ApplicationUser user)
        {
            return await DbSet.Where(x => x.ApplicationUser == user).Include(x => x.Court).Include(x => x.Court.Club).ToListAsync().ConfigureAwait(false);
        }
    }
}
