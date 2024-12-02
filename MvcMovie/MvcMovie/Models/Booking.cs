using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int SeatNr { get; set; }
        public string BookingNr { get; set; }

        [StringLength(65, MinimumLength = 1)]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Title cannot be empty or whitespace.")]
        [Required]
        public string VisitorName { get; set; }

        [StringLength(65, MinimumLength = 1)]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Title cannot be empty or whitespace.")]
        [Required]
        public string VisitorEmail { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public Movie Movies { get; set; }
    }
}
