using AdventureWorks.Application.Interfaces;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllWithCategoryAsync();

            return products.Select(p => new ProductDto
            {
                ProductID = p.ProductID,
                Name = p.Name,
                Price = p.ListPrice,
                Category = p.ProductSubcategory?.ProductCategory?.Name ?? "",
                Subcategory = p.ProductSubcategory?.Name ?? "",
            }).ToList();
        }
    }


}