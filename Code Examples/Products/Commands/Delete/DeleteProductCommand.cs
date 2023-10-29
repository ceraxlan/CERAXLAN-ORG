using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.Products.Constants;

namespace WebUI.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<DeletedProductResponse>, ILoggableRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public bool BypassCache { get; }
        public string CacheKey => ProductConstant.CacheListValue;
    }
}
