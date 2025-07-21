using MediatR;

namespace AdventureWorks.Application.Features.Orders.Queries.GetTopOrders
{
    public class GetTopOrdersQuery : IRequest<List<TopOrderDto>>
    {
        public int TopN { get; set; }
    }
}