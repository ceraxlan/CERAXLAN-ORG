using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using WebUI.Application.Services;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly LocalizerService _localization;
        public ProductBusinessRules(IProductRepository productRepository, LocalizerService localization)
        {
            _productRepository = productRepository;
            _localization = localization;
        }

        public async Task ProductNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Product> result = await _productRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(_localization.GetLocalizedKey("Exception.Product.NameExist"));
        }

        internal void ProductShouldExistWhenRequested(Product? product)
        {
            if (product == null) throw new BusinessException(_localization.GetLocalizedKey("Exception.Product.NotExist"));
        }
    }
}
