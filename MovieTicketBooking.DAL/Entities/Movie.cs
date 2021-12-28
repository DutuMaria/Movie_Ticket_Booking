using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.Entities
{
    public class Movie
    {
        public Movie()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
