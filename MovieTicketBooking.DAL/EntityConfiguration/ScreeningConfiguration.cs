using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTicketBooking.DAL.Entities;
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
                .HasColumnType("DateTime")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnType("DateTime");

            builder.HasIndex(p => p.HallId)
                .IsUnique(false);

            builder.HasOne(p => p.Hall)
              .WithMany(p => p.Screenings)
              .HasForeignKey(p => p.HallId);


            builder.HasOne(p => p.Movie)
                .WithMany(p => p.Screenings)
                .HasForeignKey(p => p.MovieId);
        }
    }
}
