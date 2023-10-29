using FluentValidation;

namespace WebUI.Application.Features.Products.Commands.Delete
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
