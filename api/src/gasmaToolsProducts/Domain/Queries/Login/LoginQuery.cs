using gasmaToolsProducts.Application.ViewModels;
using MediatR;

namespace gasmaToolsProducts.Domain.Queries.Login
{
    public class LoginQuery : IRequest<LoginViewModel>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
