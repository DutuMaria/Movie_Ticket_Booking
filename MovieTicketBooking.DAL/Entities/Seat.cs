using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Seat
    {
        public Seat()
        {
        }
        [Key]
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public int HallId { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
