using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.ProductCategories.Constants;

namespace WebUI.Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommand : IRequest<CreatedProductCategoryResponse>, ILoggableRequest, ICacheRemoverRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => ProductCategoryConstant.CacheListValue;
    }
}
