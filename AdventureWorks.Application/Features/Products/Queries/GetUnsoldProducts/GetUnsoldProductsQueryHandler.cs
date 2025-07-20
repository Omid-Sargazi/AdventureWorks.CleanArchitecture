using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AdventureWorks.Application.Features.Products.Queries.GetUnsoldProducts
{
    public class GetUnsoldProductsQueryHandler : IRequestHandler<GetUnsoldProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetUnsoldProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<ProductDto>> Handle(GetUnsoldProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetUnsoldProductsAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}