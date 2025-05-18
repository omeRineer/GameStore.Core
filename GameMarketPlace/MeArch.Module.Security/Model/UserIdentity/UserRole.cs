using Core.Entities.Abstract;

namespace MeArch.Module.Security.Model.UserIdentity
{
    public class UserRole : BaseEntity<Guid>, IEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}