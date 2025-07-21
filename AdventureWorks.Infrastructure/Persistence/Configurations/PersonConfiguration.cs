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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "Person");
            builder.HasKey(p => p.BusinessEntityID);

            builder.Property(p=>p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.LastName).IsRequired().HasMaxLength(50);

            builder.HasOne(p => p.Customer)
                .WithOne(c => c.Person)
                .HasForeignKey<Customer>(c => c.PersonID);
        }
    }
}
