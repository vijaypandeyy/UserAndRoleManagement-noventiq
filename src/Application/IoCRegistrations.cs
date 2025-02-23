using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class IoCRegistrations
    {
        public static IServiceCollection AddApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
           //services.AddScoped<IUserRepository, UserRepository>();
           //services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }

    }
}
