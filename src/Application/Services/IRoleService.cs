using Application.Models.Common;
using Application.Models.Requests;
using Application.Models.Response;

namespace Application.Services
{
    public interface IRoleService
    {
        Task<Result<GetRoleMinimalModel>> GetByIdAsync(Guid id);

        // Task<> GetUsersByFilterAsync();
        Task<Result<string>> AddAsync(AddRoleRequestModel user);
        Task<Result<string>> UpdateAsync(UpdateRoleRequestModel user);
        Task<Result<string>> DeleteAsync(Guid id);
    }
}
