using AdventureWorks.Domain.Entities;
using AdventureWorks.Infrastructure.Persistence;
using AdventureWorks.Infrastructure.Repositories;
using Azure;
using FluentAssertions;
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
        public async Task GetAllWithCategoryAsync_ShouldReturnProductWithCategoryInfo()
        {
            var context = GetInMemoryDbContext();
            var repository = new ProductRepository(context);

            var result = await repository.GetAllWithCategoryAsync();

            result.Should().NotBeNullOrEmpty();
            result[0].Name.Should().Be("Trail Bike");
            result[0].ProductSubcategory?.Name.Should().Be("Mountain Bikes");
            result[0].ProductSubcategory?.ProductCategory?.Name.Should().Be("Bikes");
        }
        
    }
}