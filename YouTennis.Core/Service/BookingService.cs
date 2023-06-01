using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Base.Service;
using YouTennis.Core.Identity;

namespace YouTennis.Core.Service
{
    public class BookingService :IBookingService
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IOpeningHoursRepository openingHoursRepository, IBookingRepository bookingRepository)
        {
            _openingHoursRepository = openingHoursRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Book(Booking booking)
        {
            return await _bookingRepository.AddAsync(booking);

        }

        public async Task<IEnumerable<Slot>> GetAvaiableSlot(int courtId, DateTime date)
        {
            var openingHours = await _openingHoursRepository.GetByCourtIdForDate(courtId, (int)date.DayOfWeek);
            var bookings = await _bookingRepository.GetByCourtForDate(courtId, date);

            int hours = openingHours.ClosingTime - openingHours.OpeningTime;
            var slots = new List<Slot>();

            for (int i = openingHours.OpeningTime; i < openingHours.ClosingTime; i++)
            {
                var slot = new Slot
                {
                    IsAvailable = true,
                    Number = i,
                    Time = $"{i}:00",
                };
                if (bookings.Any(x => x.BookingDate.Hour == i)) slot.IsAvailable = false;
                slots.Add(slot);
            }

            return slots;
        }

        public async Task<bool> CheckIfSelectedSlotIsAvaiable(int courtId, DateTime date)
        {
            var result = true;

            var openingHours = await _openingHoursRepository.GetByCourtIdForDate(courtId, (int)date.DayOfWeek);
            if (date.Hour < openingHours.OpeningTime || date.Hour > openingHours.ClosingTime) result = false;

            var booking = await _bookingRepository.GetBookingForSpecificDate(courtId, date);
            if (!(booking is null)) result = false;

            return result;
        }

        public async Task<IEnumerable<Booking>> GetBookingsForUser(ApplicationUser user)
        {
            return await _bookingRepository.GetByUser(user).ConfigureAwait(false);
        }

        public async Task Delete(Booking model)
        {
            await _bookingRepository.DeleteAsync(model).ConfigureAwait(false);
        }

        public async Task<Booking> Get(int id)
        {
            return await _bookingRepository.GetAsync(id).ConfigureAwait(false);
        }
    }
}
