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
    public class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.StartDate)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnType("Date")
                .IsRequired();

            builder.HasOne(p => p.Hall)
               .WithOne(p => p.Screening)
               .HasForeignKey<Screening>(p => p.HallId);

            builder.HasOne(p => p.Movie)
                .WithMany(p => p.Screenings)
                .HasForeignKey(p => p.MovieId);
        }
    }
}
