using System;
using YouTennis.Core.Identity;

namespace YouTennis.Base.Model
{
    public class Booking : IId
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public virtual Court Court { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
