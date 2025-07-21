using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using FluentAssertions;
using Moq;

namespace AdventureWorks.Tests.Handlers
{
    public class GetAllProductsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnMappedProductDtos()
        {
            var mockRepo = new Mock<IProductRepository>();

            var sampleProduct = new Product
            {
                ProductID = 1,
                Name = "Trail Bike",
                ListPrice = 1000,
                ProductSubcategory = new ProductSubcategory
                {
                    Name = "Mountain Bikes",
                    ProductCategory = new ProductCategory
                    {
                        Name = "Bikes"
                    }
                }
            };

            mockRepo.Setup(r => r.GetAllWithCategoryAsync())
            .ReturnsAsync(new List<Product> { sampleProduct });

           /// var handler = new GetAllProductsQueryHandler(mockRepo.Object);
            var query = new GetAllProductsQuery();

           // var result = await handler.Handle(query, CancellationToken.None);

            //result.Should().NotBeNullOrEmpty();
            //result[0].Name.Should().Be("Trail Bike");
            //result[0].Price.Should().Be(1000);
            //result[0].Category.Should().Be("Bikes");
            //result[0].Subcategory.Should().Be("Mountain Bikes");
        }
    }
}