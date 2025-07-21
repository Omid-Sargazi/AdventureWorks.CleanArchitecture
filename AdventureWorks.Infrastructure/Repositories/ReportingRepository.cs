using AdventureWorks.Application.Features.Products.Queries.GetMonthlySales;
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

        public async Task<List<MonthlySalesDto>> GetMonthlySalesAsync(int? year)
        {
            var query = from header in _context.SalesOrderHeaders
                        join detail in _context.SalesOrderDetails
                            on header.SalesOrderID equals detail.SalesOrderID
                        where !year.HasValue || header.OrderDate.Year == year.Value
                        group detail by new { header.OrderDate.Year, header.OrderDate.Month } into g
                        select new MonthlySalesDto
                        {
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            TotalOrders = g.Select(d => d.SalesOrderID).Distinct().Count(),
                            TotalQty = g.Sum(d => d.OrderQty)
                        };

            return await query
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToListAsync();
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