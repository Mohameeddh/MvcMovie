using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movies { get; set; } = default!;
        public DbSet<MvcMovie.Models.Booking> Bookings { get; set; } = default!;
        public DbSet<MvcMovie.Models.Show> Shows { get; set; } = default!;
        public DbSet<MvcMovie.Models.Salon> Salons { get; set; } = default!;
        public DbSet<MvcMovie.Models.Seat> Seats { get; set; } = default!;
    }
}
