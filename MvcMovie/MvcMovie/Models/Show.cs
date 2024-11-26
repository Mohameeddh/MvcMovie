namespace MvcMovie.Models
{
    public class Show
    {
        public int Id { get; set; }
        public required Movie Movie { get; set; }
        public required Salon Salon { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
