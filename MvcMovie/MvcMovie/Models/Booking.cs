namespace MvcMovie.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int SeatNr { get; set; }
        public string BookingNr { get; set; }
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}
