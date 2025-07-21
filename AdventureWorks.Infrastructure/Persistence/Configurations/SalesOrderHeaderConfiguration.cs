using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Infrastructure.Persistence.Configurations
{
    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.ToTable("SalesOrderHeader", "Sales");
            builder.HasKey(x => x.SalesOrderID);


            builder.HasOne(o=>o.Customer)
                .WithMany(c=>c.Orders)
                .HasForeignKey(o => o.CustomerID);
        }
    }
}