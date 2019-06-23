using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Core.Identity;

namespace YouTennis.Base.Service
{
    public interface IBookingService
    {
        Task<IEnumerable<Slot>> GetAvaiableSlot(int courtId, DateTime date);
        Task<int> Book(Booking booking);
        Task<bool> CheckIfSelectedSlotIsAvaiable(int courtId, DateTime date);
        Task<IEnumerable<Booking>> GetBookingsForUser(ApplicationUser user);
        Task Delete(Booking model);
        Task<Booking> Get(int id);
    }
}
