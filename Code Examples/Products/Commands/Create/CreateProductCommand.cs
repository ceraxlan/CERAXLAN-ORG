using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using WebUI.Application.Features.Products.Constants;

namespace WebUI.Application.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>, ILoggableRequest, ICacheRemoverRequest
    {
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
