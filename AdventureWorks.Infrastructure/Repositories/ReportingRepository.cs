using AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        private readonly ApplicationDbContext _context;
        public ReportingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int topN)
        {
            return await _context.SalesOrderDetails
            .GroupBy(d => new { d.ProductID, d.Product!.Name })
            .Select(g => new TopSellingProductDto
            {
                ProductID = g.Key.ProductID,
                Name = g.Key.Name,
                TotalSold = g.Sum(x => x.OrderQty)
            }).OrderByDescending(p => p.TotalSold)
            .Take(topN)
            .ToListAsync();
        }
    }
}