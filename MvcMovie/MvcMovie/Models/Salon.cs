using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Salon
    {
        public int Id { get; set; }

        [Range(1, 11, ErrorMessage = "SeatNr must be between 1 and 11.")]
        public int SalonNr { get; set; }

        [Range(1, 40, ErrorMessage = "SeatNr must be between 1 and 40.")]
        public int NumberOfSeats {get; set;}

        public ICollection<Show> Shows { get; set; }
    }
}
