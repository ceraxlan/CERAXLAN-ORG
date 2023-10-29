using FluentValidation;
using WebUI.Application.Services;

namespace WebUI.Application.Features.ProductCategories.Commands.Create
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        private readonly LocalizerService _localizationService;
        public CreateProductCategoryCommandValidator(LocalizerService localizationService)
        {
            _localizationService = localizationService;

            RuleFor(x => x.Name).NotEmpty().WithMessage(_localizationService.GetLocalizedKey("Exception.ProductCategory.NameNotEmpty"));

        }
    }
}
