using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Infrastructure.Persistence.Configurations
{
    public class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            builder.ToTable("ProductSubcategory", "Production");
            builder.HasKey(sc => sc.ProductSubcategoryID);
            builder.Property(sc => sc.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(sc => sc.ProductCategory)
            .WithMany(c => c.ProductSubcategories)
            .HasForeignKey(sc => sc.ProductCategoryID);
        }
    }

}