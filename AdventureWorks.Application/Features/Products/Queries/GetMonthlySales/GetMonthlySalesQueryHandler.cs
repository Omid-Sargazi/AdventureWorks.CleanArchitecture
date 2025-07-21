using AdventureWorks.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetMonthlySales
{
    public class GetMonthlySalesQueryHandler : IRequestHandler<GetMonthlySalesQuery, List<MonthlySalesDto>>
    {
        private IReportingRepository _reporting;
        public GetMonthlySalesQueryHandler(IReportingRepository reporting)
        {
            _reporting = reporting;
        }
        public async Task<List<MonthlySalesDto>> Handle(GetMonthlySalesQuery request, CancellationToken cancellationToken)
        {
            return await _reporting.GetMonthlySalesAsync(request.Year);
        }
    }
}
