namespace Application.Models.Response
{
    public class GetUserResponseModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public ISet<GetRoleMinimalModel> Roles { get; set; }
    }
}
