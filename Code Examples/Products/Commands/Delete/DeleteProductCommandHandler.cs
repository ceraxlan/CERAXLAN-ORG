using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.ProductColors.Constants;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<Product>(request);
            //var product = await _productRepository.GetAsync(x=>x.Id == request.Id);
            await _cache.RemoveAsync(ProductColorConstant.CacheListValue);
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            var deletedProduct = await _productRepository.DeleteAsync(mappedProduct);
            var deletedProductDto = _mapper.Map<DeletedProductResponse>(deletedProduct);
            return deletedProductDto;
        }
    }
}
