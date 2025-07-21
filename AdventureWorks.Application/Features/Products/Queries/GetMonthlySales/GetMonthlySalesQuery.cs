using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetMonthlySales
{
    public class GetMonthlySalesQuery : IRequest<List<MonthlySalesDto>>
    {
        public int? Year { get; set; }// filter for query
    }
}
