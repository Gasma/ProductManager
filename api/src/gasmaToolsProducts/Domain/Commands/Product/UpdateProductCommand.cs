using gasmaToolsProducts.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace gasmaToolsProducts.Domain.Commands.Product
{
    public class UpdateProductCommand : IRequest<ProductViewModel>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public IFormFile File { get; set; }
    }
}
