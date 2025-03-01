using Application.Repositories;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async override Task AddAsync(User entity)
        {
            var hasher = new PasswordHasher<object>();
            entity.Password = hasher.HashPassword(null, entity.Password);
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            // Assign Roles
            foreach (var roleId in entity.Roles)
            {
                _context.UserRoles.Add(new UserRole { UserId = entity.Id, RoleId = roleId.RoleId });
            }

            await _context.SaveChangesAsync();
        }

        public async override Task UpdateAsync(User entity)
        {
            var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == entity.Id);
            if (user == null) return;

            _context.UserRoles.RemoveRange(user.Roles);


            foreach (var roleId in entity.Roles)
            {
                _context.UserRoles.Add(new UserRole { UserId = entity.Id, RoleId = roleId.RoleId });
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePassword(Guid id, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return false;

            var hasher = new PasswordHasher<object>();
            var oldPasswordHash = hasher.HashPassword(null, oldPassword);
            var newPasswordHash = hasher.HashPassword(null, newPassword);

            if ((oldPasswordHash) != newPasswordHash)
            {
                user.Password = newPasswordHash;
            }
            await _context.SaveChangesAsync();

            return true;

            // throw new NotImplementedException();
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users
                  .Where(x => x.Id == id)
                  .Include(x => x.Roles)
                  .ThenInclude(x => x.Role)
                  .FirstOrDefaultAsync();

            return user;
        }
    }
}
