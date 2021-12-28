using MovieTicketBooking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DAL.EntityConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title)
               .HasColumnType("nvarchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500)
                .HasDefaultValue("economy");

            builder.Property(p => p.Duration)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Genre)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .HasDefaultValue("economy");

        }
    }
}
