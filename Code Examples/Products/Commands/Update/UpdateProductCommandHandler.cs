using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using NuGet.Packaging;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.ProductColors.Constants;
using WebUI.Data.Abstractions.Repositories;

namespace WebUI.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductColorRepository _productColorRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public UpdateProductCommandHandler(IProductRepository productRepository, IProductColorRepository productColorRepository, IMapper mapper, IDistributedCache cache)
        {
            _productRepository = productRepository;
            _productColorRepository = productColorRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(p => p.ProductCategory).Include(p => p.ProductColors));
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            product.Description = request.Description;
            product.Name = request.Name;
            product.ProductCategoryId = request.ProductCategoryId;
            product.ProductColors.Clear();
            var colors = _productColorRepository.GetListAsync(x => request.ProductColorIds.Contains(x.Id))?.Result?.Items;
            product.ProductColors.AddRange(colors);
            await _cache.RemoveAsync(ProductColorConstant.CacheListValue);
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            //var mappedProduct = _mapper.Map<Product>(request);           
            //var colors = _productColorRepository.GetListAsync(x => request.ProductColorIds.Contains(x.Id))?.Result?.Items;
            //mappedProduct.ProductColors.Clear();
            //mappedProduct.ProductColors.AddRange(colors);
            //product = mappedProduct;
            var updatedProduct = await _productRepository.UpdateAsync(product);
            var updatedProductDto = _mapper.Map<UpdatedProductResponse>(updatedProduct);
            return updatedProductDto;
        }
    }
}
