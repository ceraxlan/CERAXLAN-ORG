using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductCategories.Commands.Update
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, UpdatedProductCategoryResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper, IDistributedCache cache)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<UpdatedProductCategoryResponse> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedProductCategory = _mapper.Map<ProductCategory>(request);
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            var updatedProductCategory = await _productCategoryRepository.UpdateAsync(mappedProductCategory);
            var updatedProductCategoryDto = _mapper.Map<UpdatedProductCategoryResponse>(updatedProductCategory);
            return updatedProductCategoryDto;
        }
    }
}
