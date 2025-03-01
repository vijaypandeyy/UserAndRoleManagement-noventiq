using Application.Models.Requests;
using Application.Models.Response;
using Core;
using Mapster;


namespace Application.Mapping
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, GetUserResponseModel>.NewConfig();

            TypeAdapterConfig<AddUserRequestModel, User>
                    .NewConfig()
                    .Map(dest => dest.Id, src => src.Id ?? Guid.NewGuid())
                    .Map(dest => dest.Roles,
                     src => src.RoleIds != null
                        ? src.RoleIds.Select(roleId => new UserRole { RoleId = roleId }).ToHashSet()
                        : new HashSet<UserRole>());

            TypeAdapterConfig<User, GetUserResponseModel>
                            .NewConfig()
                            .Map(dest => dest.Roles,
                            src => src.Roles.Select(ur => new GetRoleMinimalModel
                            {
                                Id = ur.Role.Id,
                                Name = ur.Role.Name,
                                Description = ur.Role.Description
                            }).ToList());


        }
    }
}
