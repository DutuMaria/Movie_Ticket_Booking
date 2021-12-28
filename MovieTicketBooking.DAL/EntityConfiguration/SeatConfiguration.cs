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
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.SeatNumber)
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasOne(p => p.Hall)
                .WithMany(p => p.Seats)
                .HasForeignKey(p => p.HallId);
        }
    }
}
