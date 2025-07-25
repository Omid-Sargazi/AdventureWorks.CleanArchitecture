using AdventureWorks.Application.Interfaces;
using AdventureWorks.Domain.Entities;
using AdventureWorks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products
            .Where(p=>p.ProductSubcategoryID !=null)
            .Include(p => p.ProductSubcategory)
            .ThenInclude(sc => sc.ProductCategory)
            .ToListAsync();
        }

        public async Task<List<Product>> GetUnsoldProductsAsync()
        {
            return await _context.Products
            .Include(p => p.ProductSubcategory)
            .ThenInclude(sc => sc.ProductCategory)
            .Where(p => _context.SalesOrderDetails.Any(s => s.ProductID == p.ProductID)).ToListAsync();
        }
    }
}