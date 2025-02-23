using Application.Repositories;
using Core;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class IocRegistrations
    {
        
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }

        public static async Task InitializeDBAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync(); 

           
            if (!await context.Roles.AnyAsync())
            {
                context.Roles.AddRange(
                    new Role { Id = Guid.NewGuid(), Name = "Admin", Description="admin user" },
                    new Role { Id = Guid.NewGuid(), Name = "Viewer" , Description = "normal user" }
                );
                await context.SaveChangesAsync();
            }

           
            if (!await context.Users.AnyAsync())
            {
                var userId=Guid.NewGuid();
                var adminUser = new User
                {
                    Id= userId,
                    Username = "Admin User",
                    Email = "admin@example.com",
                    Password = "Admin@123", 
                    Roles= new List<UserRole>
                    {
                        new UserRole
                        {
                            RoleId = context.Roles.First(x=>x.Name=="Admin").Id,
                            UserId = userId

                        }
                    }.ToHashSet()
                };
                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }

    }
}
