using AdventureWorks.Domain.Entities;

namespace AdventureWorks.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllWithCategoryAsync();
    }
}