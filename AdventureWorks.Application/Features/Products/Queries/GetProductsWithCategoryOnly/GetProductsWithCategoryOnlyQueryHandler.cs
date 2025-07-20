using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetProductsWithCategoryOnly
{
    public class GetProductsWithCategoryOnlyQueryHandler : IRequestHandler<GetProductsWithCategoryOnlyQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetProductsWithCategoryOnlyQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<ProductDto>> Handle(GetProductsWithCategoryOnlyQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllWithCategoryAsync();

            var filtered = products.Where(p => p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null)
            .ToList();
            return _mapper.Map<List<ProductDto>>(filtered);
        }
    }
}