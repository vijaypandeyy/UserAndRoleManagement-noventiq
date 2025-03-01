using Application.Mapping;
using Application.Repositories;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class IoCRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IUserService, UserService>();
            
            //services.AddScoped<IRoleService, RoleService>();
            MappingConfig.RegisterMappings();
            return services;
        }

    }
}
