using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.FilterProducts
{
    public class FilterProductsQueryHandler : IRequestHandler<FilterProductsQuery, List<ProductDto>>
    {
        
        public Task<List<ProductDto>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}