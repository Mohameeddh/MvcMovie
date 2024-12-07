using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Booking
    {
        public int Id { get; set; }
        //public int? MovieId { get; set; }

        [Range(1, 40, ErrorMessage = "SeatNr must be between 1 and 40.")]
        public int SeatNr { get; set; }

        [StringLength(65, MinimumLength = 1)]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "BookingNr cannot be empty or whitespace.")]
        [Required]
        public string BookingNr { get; set; }

        [StringLength(65, MinimumLength = 1)]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Name cannot be empty or whitespace.")]
        [Required]
        public string VisitorName { get; set; }

        [StringLength(65, MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@(gmail\.com|outlook\.com)$", ErrorMessage = "Email must be from 'gmail.com' or 'outlook.com'.")]
        [Required]
        public string VisitorEmail { get; set; }

        public int? ShowId { get; set; }
        public Show? Show { get; set; }

        [Required]
        public int? SalonId { get; set; }
        public Salon? Salons { get; set; }

        [Required]
        public int? MovieId { get; set; }
        public Movie? Movies { get; set; }
    }
}
