using Core.Application.Pipelines.Caching;
using MediatR;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.ProductAnalyzes.Models;

namespace WebUI.Application.Features.ProductAnalyzes.Queries.GetList
{
    public class GetListProductAnalysisQuery : IRequest<ProductAnalysisListModel>, ICachableRequest
    {
        public bool BypassCache { get; }
        public string CacheKey => ProductAnalysisConstant.CacheListValue;
        public TimeSpan? SlidingExpiration { get; }

    }
}
