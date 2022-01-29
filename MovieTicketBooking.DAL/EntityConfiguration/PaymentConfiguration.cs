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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Total)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(p => p.Date)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(p => p.PaymentMethod)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(p => p.Booking)
                .WithOne(p => p.Payment)
                .HasForeignKey<Payment>(p => p.BookingId);
        }
    }
}
