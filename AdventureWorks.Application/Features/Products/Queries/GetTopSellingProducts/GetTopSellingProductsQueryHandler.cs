using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts
{
    public class GetTopSellingProductsQueryHandler : IRequestHandler<GetTopSellingProductsQuery, List<TopSellingProductDto>>
    {
        private readonly IReportingRepository _repository;
        public GetTopSellingProductsQueryHandler(IReportingRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<TopSellingProductDto>> Handle(GetTopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTopSellingProductsAsync(request.TopN);
        }
    }
}