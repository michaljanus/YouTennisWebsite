namespace YouTennis.Base.Model
{
    public class Court : IId
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public decimal HourPrice { get; set; }
        public string Image { get; set; }
    }
}
