using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Ticket
    {
        public Ticket()
        {
        }
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int? BookingId { get; set; }
        public int? ScreeningId { get; set; }
        public int SeatId{ get; set; } 
        public virtual Booking Booking { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
