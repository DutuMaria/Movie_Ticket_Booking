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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Date)
                .HasColumnType("Date")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(p => p.NrOfTickets)
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(p => p.Bookings)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Screening)
                .WithMany(p => p.Bookings)
                .HasForeignKey(p => p.ScreeningId);
        }
    }
}