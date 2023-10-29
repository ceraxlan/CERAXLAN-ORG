using AutoMapper;
using MediatR;
using WebUI.Application.Features.Products.Rules;
using WebUI.Data.Abstractions.Repositories;

namespace WebUI.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(x => x.Id == request.Id);

            _productBusinessRules.ProductShouldExistWhenRequested(product);

            var productGetByIdDto = _mapper.Map<GetByIdProductResponse>(product);
            return productGetByIdDto;
        }
    }
}
