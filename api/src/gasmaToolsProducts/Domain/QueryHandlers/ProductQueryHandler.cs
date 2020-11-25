using AutoMapper;
using gasmaToolsProducts.Application.ViewModels;
using gasmaToolsProducts.Data;
using gasmaToolsProducts.Domain.Queries.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Domain.QueryHandlers
{
    public class ProductQueryHandler :
        IRequestHandler<ProductDetailQuery, ProductViewModel>,
        IRequestHandler<ProductListQuery, ProductViewModel[]>
    {
        private readonly GasmaToolsContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(GasmaToolsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel[]> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToArrayAsync();

            return _mapper.Map<ProductViewModel[]>(products);
        }
    }
}
