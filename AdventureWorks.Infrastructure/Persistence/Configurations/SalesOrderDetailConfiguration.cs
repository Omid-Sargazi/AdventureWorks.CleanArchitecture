using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Infrastructure.Persistence.Configurations
{
    public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            builder.ToTable("SalesOrderDetail", "Sales");
            builder.HasKey(x => new { x.SalesOrderID, x.SalesOrderDetailID });
            builder.HasOne(d => d.Product)
            .WithMany()
            
            .HasForeignKey(d => d.ProductID);
            builder.HasOne(d => d.SalesOrderHeader)
            .WithMany(h => h.OrderDetails)
            .HasForeignKey(d => d.SalesOrderID);
        }
    }
}