using Application.Models.Common;
using Application.Models.Requests;
using Application.Models.Response;
using Application.Repositories;
using Core;
using Mapster;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
              _userRepository=userRepository;
        }
        public async Task<Result<string>> AddUserAsync(AddUserRequestModel user)
        {
            
            await _userRepository.AddAsync(user.Adapt<User>());
            return Result<string>.SuccessResult("User added successfully");
        }

        public async Task<Result<string>> DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return Result<string>.SuccessResult("User Deleted successfully");
        }

        public async Task<Result<GetUserResponseModel>> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(Guid.Parse(id));
            var res= user?.Adapt<GetUserResponseModel>();

            return Result<GetUserResponseModel>.SuccessResult(res);
        }

        public async Task<Result<string>> UpdateUserAsync(AddUserRequestModel user)
        {
            await _userRepository.UpdateAsync(user.Adapt<User>());
            return Result<string>.SuccessResult("User Updated successfully");
        }
    }
}
