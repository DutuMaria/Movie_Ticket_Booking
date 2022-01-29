using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.DAL;
using MovieTicketBooking.DAL.Entities;

namespace MovieTicketBooking.Controllers
{
    public class BookingController : ControllerBase
    {
        // injectam contextul
        // parametrii de tip private se denumesc cu _
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public BookingController(AppDbContext context, UserManager<User> userManager)
        {
            // ii dam contextul din startup
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddBooking")]
        [Authorize("user")]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            if (booking.UserId == 0)
            {
                return BadRequest("UsereId is 0!");
            }

            if (booking.ScreeningId == 0)
            {
                return BadRequest("Screening is 0!");
            }

            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetBookingsById/{id}")]
        public async Task<IActionResult> GetBookingsById([FromRoute] int id)
        {
            var bookings = await _context
                .Bookings
                .Where(x => x.UserId == id)
                .OrderBy(x => x.Date)
                .ToListAsync();

            return Ok(bookings);
        }

        [HttpGet("GetScreeningId")]
        public async Task<IActionResult> GetScreeningId([FromBody] Screening screening)
        {
            var screeningId = 0;
            var screenings = await _context.Screenings.ToListAsync();
            foreach(var s in screenings)
            {
                if(s == screening)
                {
                    screeningId = s.Id;
                }
            }
            return Ok(screeningId);
        }


        [HttpGet("GetBookings")]
        [Authorize("admin")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _context
                .Bookings
                .GroupBy(x => x.ScreeningId)
                .ToListAsync();
            return Ok(bookings);
        }



        [HttpPut("UpdateBooking/{id}")]
        [Authorize("admin")]
        public async Task<IActionResult> UpdateBooking([FromRoute] int id, [FromBody] Booking booking)
        {
            var _booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
            if (_booking != null)
            {
                _booking.UserId = booking.UserId;
                _booking.ScreeningId = booking.ScreeningId;
                _booking.Date= booking.Date;
                _booking.NrOfTickets = booking.NrOfTickets;

                await _context.SaveChangesAsync();
            }

            return Ok();
        }



        [HttpDelete("DeleteBooking/{id}")]
        [Authorize("user")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest("BookingId is 0!");
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
