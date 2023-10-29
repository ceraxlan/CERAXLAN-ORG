using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using NuGet.Packaging;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.ProductColors.Constants;
using WebUI.Application.Features.Products.Rules;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;
        private readonly IProductColorRepository _productColorRepository;
        private readonly IDistributedCache _cache;
        public CreateProductCommandHandler(IProductRepository productRepository,
            IProductColorRepository productColorRepository,
            IMapper mapper,
            ProductBusinessRules productBusinessRules,
            IDistributedCache cache)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
            _productColorRepository = productColorRepository;
            _cache = cache;
        }
        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            #region BusinessRules
            await _productBusinessRules.ProductNameCanNotBeDuplicatedWhenInserted(request.Name);
            #endregion

            #region Repository
            Product mappedProduct = _mapper.Map<Product>(request);
            var colors = _productColorRepository.GetListAsync(x => request.ProductColorIds.Contains(x.Id))?.Result?.Items;
            mappedProduct.ProductColors.AddRange(colors);
            await _cache.RemoveAsync(ProductColorConstant.CacheListValue);
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            Product createdProduct = await _productRepository.AddAsync(mappedProduct);
            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);
            #endregion

            return createdProductResponse;
        }
    }
}
