using Core.Application.Pipelines.Logging;
using MediatR;

namespace WebUI.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductResponse>, ILoggableRequest
    {
        public Guid Id { get; set; }
    }
}
