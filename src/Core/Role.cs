
namespace Core
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ISet<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
