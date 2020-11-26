using gasmaToolsProducts.Domain.Commands.Product;
using gasmaToolsProducts.Domain.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(long id)
        {
            return Ok(await _mediator.Send(new ProductDetailQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _mediator.Send(new ProductListQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
