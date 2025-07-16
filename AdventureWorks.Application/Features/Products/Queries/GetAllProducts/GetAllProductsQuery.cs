using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {

    }
}