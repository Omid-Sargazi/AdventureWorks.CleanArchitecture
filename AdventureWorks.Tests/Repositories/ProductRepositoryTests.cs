using AdventureWorks.Domain.Entities;
using AdventureWorks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var context = new ApplicationDbContext(options);

            var category = new ProductCategory
            {
                ProductCategoryID = 1,
                Name = "Bikes",
            };

            var subcategory = new ProductSubcategory
            {
                ProductSubcategoryID = 1,
                Name = "Mountain Bikes",
                ProductCategoryID = 1,
                ProductCategory = category,
            };

            var product = new Product
            {
                ProductID = 1,
                Name = "Trail Bike",
                ListPrice = 1000,
                ProductSubcategoryID = 1,
                ProductSubcategory = subcategory,
            };

            context.ProductCategories.Add(category);
            context.ProductSubcategories.Add(subcategory);
            context.Products.Add(product);
            context.SaveChanges();

            return context;
        }


        [Fact]
        
    }
}