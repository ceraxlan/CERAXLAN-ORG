using AutoMapper;
using Core.Persistence.Paging;
using WebUI.Application.Features.Products.Commands.Create;
using WebUI.Application.Features.Products.Commands.Delete;
using WebUI.Application.Features.Products.Commands.Update;
using WebUI.Application.Features.Products.Models;
using WebUI.Application.Features.Products.Queries.GetById;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreatedProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
            CreateMap<Product, ProductListDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.ProductCategory.Name))
                                                .ForMember(x => x.Colors, opt => opt.MapFrom(x => x.ProductColors));

            CreateMap<Product, UpdateProductCommand>().ForMember(x => x.ProductCategoryId, opt => opt.MapFrom(x => x.ProductCategory.Id)).ReverseMap();

            CreateMap<Product, UpdatedProductResponse>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, DeletedProductResponse>().ReverseMap();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();
            //CreateMap<Product, GetListProductListItemDto>().ReverseMap();
            //CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        }
    }
}
