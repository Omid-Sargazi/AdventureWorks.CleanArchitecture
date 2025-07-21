using AdventureWorks.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopCustomers
{
    public class GetTopCustomersQueryHandler : IRequestHandler<GetTopCustomersQuery, List<TopCustomerDto>>
    {
        private readonly IReportingRepository _reporting;
        public GetTopCustomersQueryHandler(IReportingRepository reporting)
        {
            _reporting = reporting;
        }

        public async Task<List<TopCustomerDto>> Handle(GetTopCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _reporting.GetTopCustomersAsync(request.TopN);
        }
    }
}
