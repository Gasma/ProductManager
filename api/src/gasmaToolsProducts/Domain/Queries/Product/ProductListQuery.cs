using gasmaToolsProducts.Application.ViewModels;
using MediatR;

namespace gasmaToolsProducts.Domain.Queries.Product
{
    public class ProductListQuery : IRequest<ProductViewModel[]>
    {
    }
}
