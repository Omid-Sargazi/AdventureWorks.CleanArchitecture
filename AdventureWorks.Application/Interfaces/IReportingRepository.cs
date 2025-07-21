using AdventureWorks.Application.Features.Orders.Queries.GetTopOrders;
using AdventureWorks.Application.Features.Products.Queries.GetMonthlySales;
using AdventureWorks.Application.Features.Products.Queries.GetTopCustomers;
using AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts;

namespace AdventureWorks.Application.Interfaces
{
    public interface IReportingRepository
    {
        Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int topN);
        Task<List<MonthlySalesDto>> GetMonthlySalesAsync(int? year);
        Task<List<TopCustomerDto>> GetTopCustomersAsync(int topN);
        Task<List<TopOrderDto>> GetTopOrdersAsync(int topN);
    }
}