using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Core.Identity;

namespace YouTennis.Base.Repository
{
    public interface IBookingRepository :IBaseAsync<Booking>
    {
        Task<IEnumerable<Booking>> GetByCourtForDate(int courtId, DateTime date);
        Task<Booking> GetBookingForSpecificDate(int courtId, DateTime date);
        Task<IEnumerable<Booking>> GetByUser(ApplicationUser user);
    }
}
