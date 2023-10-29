using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.Products.Constants;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductCategories.Commands.Delete
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, DeletedProductCategoryResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper, IDistributedCache cache)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<DeletedProductCategoryResponse> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedProductCategory = _mapper.Map<ProductCategory>(request);
            //var productCategory = await _productCategoryRepository.GetAsync(x=>x.Id == request.Id);
            var deletedProductCategory = await _productCategoryRepository.DeleteAsync(mappedProductCategory);
            await _cache.RemoveAsync(ProductConstant.CacheListValue);
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            var deletedProductCategoryDto = _mapper.Map<DeletedProductCategoryResponse>(deletedProductCategory);
            return deletedProductCategoryDto;
        }
    }
}
