namespace MvcMovie.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public int SalonNr { get; set; }
        public int NumberOfSeats {get; set;}
        public ICollection<Show> Shows { get; set; }
    }
}
