using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Domain.Entities;
using AutoMapper;

namespace AdventureWorks.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(desc => desc.Category, opt => opt.MapFrom(src => src.ProductSubcategory!.ProductCategory!.Name))
            .ForMember(desc => desc.Subcategory, opt => opt.MapFrom(src => src.ProductSubcategory!.Name));
        }
    }
}