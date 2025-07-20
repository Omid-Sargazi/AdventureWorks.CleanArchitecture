using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetUnsoldProducts
{
    public class GetUnsoldProductsQuery : IRequest<List<ProductDto>>
    {

    }
}