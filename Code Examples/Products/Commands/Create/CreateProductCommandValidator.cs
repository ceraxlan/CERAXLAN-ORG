using FluentValidation;
using WebUI.Application.Services;

namespace WebUI.Application.Features.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly LocalizerService _localizationService;
        public CreateProductCommandValidator(LocalizerService localizationService)
        {
            _localizationService = localizationService;
            RuleFor(x => x.Name).NotEmpty().WithMessage(_localizationService.GetLocalizedKey("Exception.Product.NameNotEmpty"));
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage(_localizationService.GetLocalizedKey("Exception.Product.PriceNotEmpty"));
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0).WithMessage(_localizationService.GetLocalizedKey("Exception.Product.QuantityNotEmpty"));
        }
    }
}
