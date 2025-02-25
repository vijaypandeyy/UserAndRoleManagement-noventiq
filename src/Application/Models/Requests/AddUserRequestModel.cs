namespace Application.Models.Requests
{
    public class AddUserRequestModel
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ISet<Guid> RoleIds { get; set; }
    }
}
