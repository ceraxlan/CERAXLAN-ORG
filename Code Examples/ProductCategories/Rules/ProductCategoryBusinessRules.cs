using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using WebUI.Application.Services;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductCategories.Rules
{
    public class ProductCategoryBusinessRules
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly LocalizerService _localizationService;

        public ProductCategoryBusinessRules(IProductCategoryRepository productCategoryRepository, LocalizerService localizationService)
        {
            _productCategoryRepository = productCategoryRepository;
            _localizationService = localizationService;
        }

        public async Task ProductCategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProductCategory> result = await _productCategoryRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(_localizationService.GetLocalizedKey("Exception.ProductCategory.NameExist"));
        }

        internal void ProductCategoryShouldExistWhenRequested(ProductCategory? productCategory)
        {
            if (productCategory == null) throw new BusinessException(_localizationService.GetLocalizedKey("Exception.ProductCategory.NotExist"));
        }
    }
}
