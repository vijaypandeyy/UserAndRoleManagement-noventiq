namespace Application.Models.Response
{
    public class GetUserResponseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public ISet<GetRoleMinimalModel> Roles { get; set; }
    }
}
