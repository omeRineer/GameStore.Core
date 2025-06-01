using Core.Entities.Abstract;

namespace MeArch.Module.Security.Entities.Master
{
    public class UserRole : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}