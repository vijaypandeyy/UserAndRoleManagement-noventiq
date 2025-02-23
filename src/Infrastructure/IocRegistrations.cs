using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class IocRegistrations
    {
        public static IServiceCollection AddInfrastructureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }

    }
}
