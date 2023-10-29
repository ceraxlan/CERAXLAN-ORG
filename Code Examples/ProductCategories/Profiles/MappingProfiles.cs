using AutoMapper;
using Core.Persistence.Paging;
using WebUI.Application.Features.ProductCategories.Commands.Create;
using WebUI.Application.Features.ProductCategories.Commands.Delete;
using WebUI.Application.Features.ProductCategories.Commands.Update;
using WebUI.Application.Features.ProductCategories.Models;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductCategories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductCategory, CreatedProductCategoryResponse>().ReverseMap();
            CreateMap<ProductCategory, CreateProductCategoryCommand>().ReverseMap();

            CreateMap<IPaginate<ProductCategory>, ProductCategoryListModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryListDto>().ReverseMap();

            CreateMap<ProductCategory, UpdateProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, UpdatedProductCategoryResponse>().ReverseMap();
            CreateMap<ProductCategory, DeleteProductCategoryCommand>().ReverseMap();
            CreateMap<ProductCategory, DeletedProductCategoryResponse>().ReverseMap();
            //CreateMap<ProductCategory, GetByIdProductCategoryResponse>().ReverseMap();
            //CreateMap<ProductCategory, GetListProductCategoryListItemDto>().ReverseMap();
            //CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        }
    }
}
