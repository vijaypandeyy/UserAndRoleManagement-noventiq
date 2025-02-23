namespace Core
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public ISet<Role> Roles { get; set; }
    }
}
