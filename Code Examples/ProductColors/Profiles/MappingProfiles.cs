using AutoMapper;
using Core.Persistence.Paging;
using WebUI.Application.Features.ProductColors.Models;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductColors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<ProductColor, CreatedProductColorResponse>().ReverseMap();
            //CreateMap<ProductColor, CreateProductColorCommand>().ReverseMap();

            CreateMap<IPaginate<ProductColor>, ProductColorListModel>().ReverseMap();
            CreateMap<ProductColor, ProductColorListDto>().ForMember(x => x.ProductCount, opt => opt.MapFrom(x => x.Products.Sum(x => x.Quantity)));

            //CreateMap<ProductColor, UpdateProductColorCommand>().ReverseMap();
            //CreateMap<ProductColor, UpdatedProductColorResponse>().ReverseMap();
            //CreateMap<ProductColor, DeleteProductColorCommand>().ReverseMap();
            //CreateMap<ProductColor, DeletedProductColorResponse>().ReverseMap();
            //CreateMap<ProductColor, GetByIdProductColorResponse>().ReverseMap();
            //CreateMap<ProductColor, GetListProductColorListItemDto>().ReverseMap();
            //CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
        }
    }
}
