
namespace Core
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ISet<UserRole> Roles { get; set; }
    }
}
