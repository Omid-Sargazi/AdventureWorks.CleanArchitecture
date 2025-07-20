using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.FilterProducts
{
    public class FilterProductsQuery : IRequest<List<ProductDto>>
    {
        public decimal MinPrice { get; set; }
        public string? Category { get; set; }
    }
}