using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopOrders
{
    public class GetTopOrdersQueryHandler : IRequestHandler<GetTopOrdersQuery, List<TopOrderDto>>
    {
        private readonly IReportingRepository _reporting;
        public GetTopOrdersQueryHandler(IReportingRepository reporting)
        {
            _reporting = reporting;
        }
        public async Task<List<TopOrderDto>> Handle(GetTopOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _reporting.GetTopOrdersAsync(request.TopN);
        }
    }
}