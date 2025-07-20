using AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts;

namespace AdventureWorks.Application.Interfaces
{
    public interface IReportingRepository
    {
        Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int topN);
    }
}