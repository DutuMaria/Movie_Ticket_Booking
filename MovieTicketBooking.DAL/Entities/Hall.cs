using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Hall
    {
        public Hall()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
