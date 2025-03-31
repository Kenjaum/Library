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
    public class LoanConfigurations : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.IdBook)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
