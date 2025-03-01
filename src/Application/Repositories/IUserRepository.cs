using Core;

namespace Application.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<bool> UpdatePassword(Guid id,string oldPassword, string newPassword);
    }
}
