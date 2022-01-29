using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Booking
    {
        public Booking()
        {
        }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int NrOfTickets { get; set; } //default 1, required
        public int UserId { get; set; }
        public int ScreeningId { get; set; }
        public virtual User User { get; set; }
        public virtual Screening Screening { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
