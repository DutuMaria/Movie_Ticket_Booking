using MovieTicketBooking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.DAL.EntityConfiguration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Price)
              .HasColumnType("decimal(4,2)")
              .IsRequired();

            builder.HasOne(p => p.Booking)
               .WithMany(p => p.Tickets)
               .HasForeignKey(p => p.BookingId);

            builder.HasOne(p => p.Screening)
               .WithMany(p => p.Tickets)
               .HasForeignKey(p => p.ScreeningId);

            builder.HasOne(p => p.Seat)
                .WithOne(p => p.Ticket)
                .HasForeignKey<Ticket>(p => p.SeatId);
        }
    }
}
