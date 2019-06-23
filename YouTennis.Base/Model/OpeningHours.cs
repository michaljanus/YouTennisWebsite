using System;

namespace YouTennis.Base.Model
{
    public class OpeningHours : IId
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public int DayId { get; set; }
        public int OpeningTime { get; set; }
        public int ClosingTime { get; set; }
    }
}
