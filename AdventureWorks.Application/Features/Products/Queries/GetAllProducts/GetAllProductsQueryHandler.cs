using AdventureWorks.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllWithCategoryAsync();

            // return products.Select(p => new ProductDto
            // {
            //     ProductID = p.ProductID,
            //     Name = p.Name,
            //     ListPrice = p.ListPrice,
            //     Category = p.ProductSubcategory?.ProductCategory?.Name ?? "",
            //     Subcategory = p.ProductSubcategory?.Name ?? "",
            // }).ToList();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }


}