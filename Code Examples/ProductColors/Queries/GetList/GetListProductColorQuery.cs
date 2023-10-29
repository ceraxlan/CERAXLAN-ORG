using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using WebUI.Application.Features.ProductColors.Constants;
using WebUI.Application.Features.ProductColors.Models;

namespace WebUI.Application.Features.ProductColors.Queries.GetList
{
    public class GetListProductColorQuery : IRequest<ProductColorListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => ProductColorConstant.CacheListValue;
        public TimeSpan? SlidingExpiration { get; }
    }
}
