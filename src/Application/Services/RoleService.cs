using Application.Models.Common;
using Application.Models.Requests;
using Application.Models.Response;
using Application.Repositories;
using Core;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result<string>> AddAsync(AddRoleRequestModel role)
        {
            await _roleRepository.AddAsync(role.Adapt<Role>());
            return Result<string>.SuccessResult("Role added successfully");
        }

        public async Task<Result<string>> DeleteAsync(Guid id)
        {
            await _roleRepository.DeleteAsync(id);
            return Result<string>.SuccessResult("Role Delete successfully");
        }
        public async Task<Result<string>> UpdateAsync(UpdateRoleRequestModel role)
        {
            await _roleRepository.UpdateAsync(role.Adapt<Role>());
            return Result<string>.SuccessResult("Role Updated successfully");
        }
        public async Task<Result<GetRoleMinimalModel>> GetByIdAsync(Guid id)
        {
            var res= await _roleRepository.GetByIdAsync(id);
            return Result<GetRoleMinimalModel>.SuccessResult(res.Adapt<GetRoleMinimalModel>());
        }
    }




}


