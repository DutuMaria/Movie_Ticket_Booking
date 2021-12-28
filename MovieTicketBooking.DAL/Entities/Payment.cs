using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Payment
    {
        public Payment()
        {
        }
        [Key]
        public int Id { get; set; } 
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }

    }
}
