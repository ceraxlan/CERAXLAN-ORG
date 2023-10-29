using FluentValidation;
using WebUI.Application.Services;

namespace WebUI.Application.Features.Products.Commands.Update
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly LocalizerService _localizationService;
        public UpdateProductValidator(LocalizerService localizationService)
        {
            _localizationService = localizationService;
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().WithMessage(_localizationService.GetLocalizedKey("Exception.Product.NameNotEmpty"));
            //RuleFor(x => x.Price).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(100000).WithMessage(_localizationService.GetLocalizedKey("Exception.Product.PriceNotEmpty"));
            RuleFor(x => x.Quantity).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(100000).WithMessage(_localizationService.GetLocalizedKey("Exception.Product.QuantityNotEmpty"));

        }
    }
}
