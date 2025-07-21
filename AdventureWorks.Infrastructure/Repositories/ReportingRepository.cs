using AdventureWorks.Application.Features.Orders.Queries.GetTopOrders;
using AdventureWorks.Application.Features.Products.Queries.GetMonthlySales;
using AdventureWorks.Application.Features.Products.Queries.GetTopCustomers;
using AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

       

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int topN)
        {
            var result = await _context.SalesOrderHeaders
         .Where(h => h.Customer != null && h.Customer.Person != null)
         .SelectMany(h => h.OrderDetails.Select(d => new
         {
             h.Customer.CustomerID,
             h.Customer.Person.FirstName,
             h.Customer.Person.LastName,
             d.LineTotal
         }))
         .GroupBy(x => new
         {
             x.CustomerID,
             x.FirstName,
             x.LastName
         })
         .Select(g => new TopCustomerDto
         {
             CustomerID = g.Key.CustomerID,
             FullName = g.Key.FirstName + " " + g.Key.LastName,
             TotalSales = g.Sum(x => x.LineTotal)
         })
         .OrderByDescending(x => x.TotalSales)
         .Take(topN)
         .ToListAsync();

            return result;
        }

        public async Task<List<TopOrderDto>> GetTopOrdersAsync(int topN)
        {
             var result = await _context.SalesOrderHeaders
            .Include(o => o.Customer)
            .ThenInclude(c => c.Person)
            .Include(o => o.OrderDetails)
            .Where(o => o.OrderDetails.Any())
            .Select(o => new TopOrderDto
            {
                SalesOrderID = o.SalesOrderID,
                CustomerName = (o.Customer!.Person != null)
                ? o.Customer.Person.FirstName + " " + o.Customer.Person.LastName
                : "Unknown",
                TotalItems = o.OrderDetails.Sum(d => d.OrderQty)
            })
            .OrderByDescending(x => x.TotalItems)
            .Take(topN)
            .ToListAsync();
            return result; 
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