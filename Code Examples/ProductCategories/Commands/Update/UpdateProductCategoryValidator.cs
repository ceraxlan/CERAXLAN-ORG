using FluentValidation;
using WebUI.Application.Services;

namespace WebUI.Application.Features.ProductCategories.Commands.Update
{
    public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        private readonly LocalizerService _localizationService;
        public UpdateProductCategoryValidator(LocalizerService localizationService)
        {
            _localizationService = localizationService;
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().WithMessage(_localizationService.GetLocalizedKey("Exception.ProductCategory.NameNotEmpty"));
        }
    }
}
