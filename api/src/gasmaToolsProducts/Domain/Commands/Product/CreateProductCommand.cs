using gasmaToolsProducts.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace gasmaToolsProducts.Domain.Commands.Product
{
    public class CreateProductCommand : IRequest<ProductViewModel>
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public IFormFile File { get; set; }
    }
}
