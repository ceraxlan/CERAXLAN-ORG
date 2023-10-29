using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.ProductCategories.Constants;

namespace WebUI.Application.Features.ProductCategories.Commands.Update
{
    public class UpdateProductCategoryCommand : IRequest<UpdatedProductCategoryResponse>, ILoggableRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => ProductCategoryConstant.CacheListValue;
    }
}
