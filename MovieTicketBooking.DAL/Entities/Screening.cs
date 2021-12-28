using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Screening
    {
        public Screening()
        {
        }
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HallId { get; set; } 
        public int MovieId { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
