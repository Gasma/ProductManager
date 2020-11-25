using gasmaToolsProducts.Domain.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
