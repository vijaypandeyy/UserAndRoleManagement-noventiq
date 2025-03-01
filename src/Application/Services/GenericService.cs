using Application.Models.Common;
using Application.Models.Requests;
using Application.Models.Response;
using Application.Repositories;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //public class GenericService<Entity, TAddModel, TUpdateModel, TReponseModel> : IGenericService<Entity, TAddModel, TUpdateModel, TReponseModel>
    //{
    //    private readonly IGenericRepository<Entity> _userRepository;
    //    public GenericService(IGenericRepository<Entity> userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }
    //    public async Task<Result<string>> AddUserAsync(TAddModel user)
    //    {

    //        await _userRepository.AddAsync(user.Adapt<Entity>());
    //        return Result<string>.SuccessResult("User added successfully");
    //    }

    //    public async Task<Result<string>> DeleteUserAsync(Guid id)
    //    {
    //        await _userRepository.DeleteAsync(id);
    //        return Result<string>.SuccessResult("User Deleted successfully");
    //    }

    //    public async Task<Result<GetUserResponseModel>> GetUserByIdAsync(string id)
    //    {
    //        var user = await _userRepository.GetByIdAsync(Guid.Parse(id));
    //        var res = user?.Adapt<GetUserResponseModel>();

    //        return Result<GetUserResponseModel>.SuccessResult(res);
    //    }

    //    public async Task<Result<string>> UpdateUserAsync(AddUserRequestModel user)
    //    {
    //        await _userRepository.UpdateAsync(user.Adapt<User>());
    //        return Result<string>.SuccessResult("User Updated successfully");
    //    }
    //}
}
