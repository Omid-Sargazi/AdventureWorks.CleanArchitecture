using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.FilterProducts
{
    public class FilterProductsQueryHandler : IRequestHandler<FilterProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public FilterProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllWithCategoryAsync();

            var filtered = products
            .Where(p => p.ListPrice >= request.MinPrice)
            .Where(p => string.IsNullOrEmpty(request.Category) ||
                (p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null
                    && p.ProductSubcategory.ProductCategory.Name == request.Category
                )
            ).ToList();

            return _mapper.Map<List<ProductDto>>(filtered);
            
        }
    }
}