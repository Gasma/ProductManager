using FluentValidation;
using gasmaToolsProducts.Domain.Models;

namespace gasmaToolsProducts.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(255)
                .WithMessage("The name max length is 255 characters");            
            
            RuleFor(a => a.Price)
                .NotEmpty()
                .WithMessage("Price is required");
        }
    }
}
