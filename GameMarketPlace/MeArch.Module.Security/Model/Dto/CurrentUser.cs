using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Model.Dto
{
    public class CurrentUser
    {
        public Guid? Id { get; init; }
        public string? Name { get; init; }
        public string? Phone { get; init; }
        public string? Email { get; init; }
        public string[]? Roles { get; init; }
        public string[]? Permissions { get; init; }
        public bool IsAuthenticated { get; set; }

    }
}
