using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class BookingsController : Controller
    {
        private readonly MvcMovieContext _context;

        public BookingsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Bookings.Include(b => b.Show);
            return View(await mvcMovieContext.ToListAsync());
        }

        public IActionResult Booking()
        {
            return View();
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpGet]
        public IActionResult Booking(int showId)
        {
            var totalSeats = 40;
            var bookedSeats = _context.Bookings
                .Select(b => b.SeatNr)
                .ToList();

            var availableSeats = Enumerable.Range(1, totalSeats)
                                           .Where(seat => !bookedSeats.Contains(seat))
                                           .ToList();
            ViewData["AvailableSeats"] = new SelectList(availableSeats);

            var booking = new Booking { ShowId = showId };
            return View(booking);
        }


       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking(Booking booking)
        {
            // Om ShowId inte är satt, sätt den till ett standardvärde eller hämta det från en annan källa
            //teeeeeeesst
            if (booking.ShowId == null || booking.ShowId == 0)
            {
                // Exempel: Hämta ett ShowId från databasen eller sätt ett standardvärde
                booking.ShowId = _context.Shows.FirstOrDefault()?.Id; // Hämta det första ShowId:t från databasen
                // Eller sätt ett specifikt värde för showId om det är känt (t.ex. en parameter i URL)
            }

            if (_context.Bookings.Any(b => b.ShowId == booking.ShowId && b.SeatNr == booking.SeatNr))
            {
                ModelState.AddModelError("SeatNr", "This seat is already booked.");
                return View(booking);
            }

            // Generera bokningsnummer och lägg till bokning
            booking.BookingNr = GenerateBookingNumber();
            _context.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("Confirmation", new { bookingNr = booking.BookingNr });
        }

        private string GenerateBookingNumber()
        {
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        public IActionResult Confirmation(string bookingNr)
        {
            var booking = _context.Bookings
                .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
                .Include(b => b.Show.Salon)
                .FirstOrDefault(b => b.BookingNr == bookingNr);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", booking.ShowId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeatNr,BookingNr,VisitorName,VisitorEmail,ShowId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", booking.ShowId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult Find()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Find(string bookingNr)
        {
            if (string.IsNullOrEmpty(bookingNr))
            {
                ViewBag.Message = "Please enter a valid booking number.";
                return View();
            }

            var booking = _context.Bookings
                .Include(b => b.Show)
                .ThenInclude(s => s.Movie)
                .Include(b => b.Show.Salon)
                .FirstOrDefault(b => b.BookingNr == bookingNr);

            if (booking == null)
            {
                ViewBag.Message = "Booking not found. Please check your booking number.";
                return View();
            }

            return RedirectToAction("Confirmation", new { bookingNr });
        }
    }
}
