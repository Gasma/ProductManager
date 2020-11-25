using gasmaToolsProducts.Application.ViewModels;
using MediatR;

namespace gasmaToolsProducts.Domain.Queries.Product
{
    public class ProductDetailQuery : IRequest<ProductViewModel>
    {
        public long Id { get; set; }
    }
}
