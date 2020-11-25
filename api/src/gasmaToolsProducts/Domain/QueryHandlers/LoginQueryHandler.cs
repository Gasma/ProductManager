using gasmaToolsProducts.Application.ViewModels;
using gasmaToolsProducts.Configuration.Settings;
using gasmaToolsProducts.Domain.Notification;
using gasmaToolsProducts.Domain.Queries.Login;
using gasmaToolsProducts.Helper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Domain.QueryHandlers
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginViewModel>
    {
        private readonly NotificationContext _notification;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IRequestHelper _requestHelper;
        private readonly AuthSettings _authSettings;

        public LoginQueryHandler(NotificationContext notification, IJwtGenerator jwtGenerator, 
            IRequestHelper requestHelper, IOptions<AuthSettings> config)
        {
            _notification = notification;
            _jwtGenerator = jwtGenerator;
            _requestHelper = requestHelper;
            _authSettings = config.Value;
        }

        public async Task<LoginViewModel> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _requestHelper.SendRequest(_authSettings.Url, request.Password, request.Username );

            if (!user.Success)
            {
                _notification.AddNotification("Usuário", "Usuario ou senha incorretos");
                return null;
            }

            return new LoginViewModel
            {
                Token = _jwtGenerator.CreateToken()
            };
        }
    }
}
