using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.ProductCategories.Constants;

namespace WebUI.Application.Features.ProductCategories.Commands.Delete
{
    public class DeleteProductCategoryCommand : IRequest<DeletedProductCategoryResponse>, ILoggableRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => ProductCategoryConstant.CacheListValue;
    }
}
