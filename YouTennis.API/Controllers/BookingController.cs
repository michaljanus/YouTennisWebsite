using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YouTennis.API.VievModel;
using YouTennis.Base.Model;
using YouTennis.Base.Service;
using YouTennis.Core.Exception;

namespace YouTennis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;

        public BookingController(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
        }

        [Route("GetSlots/{courtId}/{date}")]
        [HttpGet]
        public async Task<IActionResult> GetSlots(int courtId, DateTime date)
        {
            var slots = await _bookingService.GetAvaiableSlot(courtId, date);

            return Ok(slots);
        }

        [Route("Book/{courtId}/{date}")]
        public async Task<IActionResult> Book(int courtId, DateTime date)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var appUser = await _userService.GetById(userId);

            var booking = new Booking
            {
                BookingDate = date,
                CourtId = courtId,
                ApplicationUser = appUser,
            };

            if (await _bookingService.CheckIfSelectedSlotIsAvaiable(courtId, date))
            {
                var result = await _bookingService.Book(booking);
                return Ok(result);
            }

            return BadRequest("Selected slot is not avaiable");
        }

        [Route("MyBookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var appUser = await _userService.GetById(userId);

            var bookings = await _bookingService.GetBookingsForUser(appUser);

            var result = new List<BookingViewModel>();

            foreach(var booking in bookings)
            {
                result.Add(new BookingViewModel
                {
                    Id = booking.Id,
                    CourtId = booking.CourtId,
                    BookingDate = booking.BookingDate,
                    BookingDateAsString = booking.BookingDate.ToString("dd-MM-yyyy HH:mm"),
                    CourtAddress = $"{booking.Court.Street} {booking.Court.StreetNumber} {booking.Court.ZipCode} {booking.Court.City}",
                    ClubName = booking.Court?.Club?.Name
                });         
            }

            return Ok(result);
        }

        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _bookingService.Get(id);
            if (item is null) throw new NotFoundException();

            await _bookingService.Delete(item);

            return Ok();
        }
    }
}