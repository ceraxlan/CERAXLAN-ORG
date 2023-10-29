using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using WebUI.Application.Features.ProductCategories.Constants;
using WebUI.Application.Features.ProductCategories.Models;

namespace WebUI.Application.Features.ProductCategories.Queries.GetList
{
    public class GetListProductCategoryQuery : IRequest<ProductCategoryListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => ProductCategoryConstant.CacheListValue;
        public TimeSpan? SlidingExpiration { get; }
    }
}
