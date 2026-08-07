using AirbnbCloneBackend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Infrastructure.Persistance.Configurations
{
    public class PropertyConnfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            // Table Name
            builder.ToTable("Properties");

            //Primary Key
            builder.HasKey(p => p.Id);

            //Required Columns
            builder.Property(p => p.PropertyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Location)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            // Other Columns
            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Property(p => p.FileName)
                .IsRequired()
                .HasMaxLength(150);

            // Other columns 
            // Okay with EF Core default conventions

            // Relationship Configuration : One-to-Many Relationship (User - Property)
            builder.HasOne(p => p.User)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
