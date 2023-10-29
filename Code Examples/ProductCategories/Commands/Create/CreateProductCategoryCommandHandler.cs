using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Application.Features.ProductAnalyzes.Constants;
using WebUI.Application.Features.ProductCategories.Rules;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, CreatedProductCategoryResponse>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;
        private readonly IDistributedCache _cache;
        public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper, ProductCategoryBusinessRules productCategoryBusinessRules, IDistributedCache cache)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _productCategoryBusinessRules = productCategoryBusinessRules;
            _cache = cache;
        }
        public async Task<CreatedProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            #region BusinessRules
            await _productCategoryBusinessRules.ProductCategoryNameCanNotBeDuplicatedWhenInserted(request.Name);
            #endregion
            await _cache.RemoveAsync(ProductAnalysisConstant.CacheListValue);
            #region Repository
            ProductCategory mappedProductCategory = _mapper.Map<ProductCategory>(request);
            ProductCategory createdProductCategory = await _productCategoryRepository.AddAsync(mappedProductCategory);
            CreatedProductCategoryResponse createdProductCategoryResponse = _mapper.Map<CreatedProductCategoryResponse>(createdProductCategory);
            #endregion

            return createdProductCategoryResponse;
        }
    }
}
