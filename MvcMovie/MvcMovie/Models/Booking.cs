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
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Email cannot be empty or whitespace.")]
        [Required]
        public string VisitorEmail { get; set; }

        public int? ShowId { get; set; }
        public Show? Show { get; set; }
        //public Movie? Movies { get; set; }
    }
}
