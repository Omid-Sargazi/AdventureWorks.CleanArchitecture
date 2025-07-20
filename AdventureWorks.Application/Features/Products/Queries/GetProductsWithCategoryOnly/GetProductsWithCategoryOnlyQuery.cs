using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetProductsWithCategoryOnly
{
    public class GetProductsWithCategoryOnlyQuery : IRequest<List<ProductDto>>
    {

    }
}