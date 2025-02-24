using Application.Models.Common;
using Application.Models.Requests;
using Application.Models.Response;
using Core;

namespace Application.Services
{
    public interface IUserService
    {
        Task<Result<GetUserResponseModel>> GetUserByIdAsync(Guid id);

        // Task<> GetUsersByFilterAsync();
        Task<Result<string>> AddUserAsync(AddUserRequestModel user);
        Task<Result<string>> UpdateUserAsync(AddUserRequestModel user);
        Task<Result<string>> DeleteUserAsync(Guid id);
    }
}
