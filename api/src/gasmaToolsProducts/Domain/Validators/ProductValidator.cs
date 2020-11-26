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
                .MaximumLength(100)
                .WithMessage("Nome do Produto deve ter no maximo 100 caracteres.");            
            
            RuleFor(a => a.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que 0.");
        }
    }
}
