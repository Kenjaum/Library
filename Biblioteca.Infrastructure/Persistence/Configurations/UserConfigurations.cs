using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Name)
                .HasMaxLength(100);

            builder
                .Property(u => u.Email)
                .HasMaxLength(100);

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Role)
                .HasMaxLength(100);

            builder
                .Property(u => u.Password)
                .HasMaxLength(100);

            builder
                .HasMany(u => u.Loans)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
