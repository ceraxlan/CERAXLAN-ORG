using FluentValidation;

namespace WebUI.Application.Features.ProductCategories.Commands.Delete
{
    public class DeleteProductCategoryValidator : AbstractValidator<DeleteProductCategoryCommand>
    {
        public DeleteProductCategoryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
