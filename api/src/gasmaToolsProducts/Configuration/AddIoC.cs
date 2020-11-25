using gasmaToolsProducts.Domain.Notification;
using gasmaToolsProducts.Domain.Validators.Base;
using gasmaToolsProducts.Helper;
using Microsoft.AspNetCore.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddIoC
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IRequestHelper, RequestHelper>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<NotificationContext>();
            services.AddScoped<IEntityValidator, EntityValidator>();

            return services;
        }
    }
}
