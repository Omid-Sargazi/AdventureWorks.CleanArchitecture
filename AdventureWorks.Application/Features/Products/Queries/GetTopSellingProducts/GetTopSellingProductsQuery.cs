using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts
{
    public class GetTopSellingProductsQuery : IRequest<List<TopSellingProductDto>>
    {
        public int TopN { get; set; } = 10;
    }
}