using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Sales");
            builder.HasKey(c => c.CustomerID);

            builder.HasOne(c => c.Person)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(c => c.PersonID);

            builder.HasMany(c=>c.Orders)
                .WithOne(o=>o.Customer)
                .HasForeignKey(o => o.CustomerID);
        }
    }
}
