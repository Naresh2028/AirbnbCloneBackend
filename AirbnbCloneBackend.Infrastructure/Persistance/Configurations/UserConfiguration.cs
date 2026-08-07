using AirbnbCloneBackend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirbnbCloneBackend.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            // Table Name
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            // Required Columns
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                
                .HasMaxLength(100);

            builder.Property(p => p.PasswordHash)
                .IsRequired()
                .HasMaxLength(150);

            // Other columns 
            //  EF Core conventions are sufficient for the remaining properties.

            // Navigation Relationship
            // No explicit configuration is required, as the EF core convention will satisfy either one class's config is enough.
        }
    }
}
