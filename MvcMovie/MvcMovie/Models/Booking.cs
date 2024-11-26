namespace MvcMovie.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int SeatNr { get; set; }
        public int BookingNr { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
