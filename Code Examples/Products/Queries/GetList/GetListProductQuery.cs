using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using WebUI.Application.Features.Products.Constants;
using WebUI.Application.Features.Products.Models;

namespace WebUI.Application.Features.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<ProductListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => ProductConstant.CacheListValue;
        public TimeSpan? SlidingExpiration { get; }
    }
}
