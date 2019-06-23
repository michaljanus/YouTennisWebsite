using System;

namespace YouTennis.API.VievModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingDateAsString { get; set; }
        public string CourtAddress { get; set; }
        public string ClubName { get; set; }
    }
}
