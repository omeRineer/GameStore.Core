using Core.Entities.Abstract;
using MeArch.Module.Security.Entities.Master;

namespace MeArch.Module.Security.Entities.Menu
{
    public class MenuPermission : BaseEntity<Guid>
    {
        public Guid MenuId { get; set; }
        public Guid PermissionId { get; set; }

        public Menu Menu { get; set; }
        public Permission Permission { get; set; }
    }
}
