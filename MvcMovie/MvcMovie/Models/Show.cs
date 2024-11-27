﻿namespace MvcMovie.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
