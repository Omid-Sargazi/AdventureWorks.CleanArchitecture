using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopCustomers
{
    public class GetTopCustomersQuery : IRequest<List<TopCustomerDto>>
    {
        public int? TopN { get; set; } = 10;
    }
}
