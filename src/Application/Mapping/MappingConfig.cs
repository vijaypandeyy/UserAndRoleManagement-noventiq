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
     .Map(dest => dest.Roles,
                     src => src.RoleIds != null
                        ? src.RoleIds.Select(roleId => new UserRole { RoleId = roleId }).ToHashSet()
                        : new HashSet<UserRole>())
      ;


        }
    }
}
