using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Migrations
{
    public static class DbSeed
    {
        public static async Task SeedDataAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync(); 

           
            if (!await context.Roles.AnyAsync())
            {
                context.Roles.AddRange(
                    new Role { Id = Guid.NewGuid(), Name = "Admin",Description="for admin user" },
                    new Role { Id = Guid.NewGuid(), Name = "Reader",Description="for normal user" }
                );
                await context.SaveChangesAsync();
            }
           
            if (!await context.Users.AnyAsync())
            {
                var adminUser = new User
                {
                    Username = "Vijay Pandey",
                    Email = "admin@example.com",
                    Password = "Admin@123", 
                };
                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
