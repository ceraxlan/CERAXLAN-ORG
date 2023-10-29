using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.Products.Constants;

namespace WebUI.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdatedProductResponse>, ILoggableRequest, ICacheRemoverRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductCategoryId { get; set; }
        public List<Guid> ProductColorIds { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => ProductConstant.CacheListValue;
    }
}
