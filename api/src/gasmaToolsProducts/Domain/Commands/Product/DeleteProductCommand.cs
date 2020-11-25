using MediatR;

namespace gasmaToolsProducts.Domain.Commands.Product
{
    public class DeleteProductCommand : IRequest
    {
        public long Id { get; set; }
    }
}
