using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Filters
{
    public class Authorize : AuthorizeAttribute, IAuthorizationFilter
    {
        readonly string[] Claims;

        public Authorize(string claims = null)
        {
            if (claims != null)
            {
                Claims = new string[]
                {
                    "SuperAdmin"
                }
                .Concat(claims.Split(',')).ToArray();
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (Claims == null)
                return;

            var userRoles = user.Claims.Where(f => f.Type == ClaimTypes.Role);
            var userPermissions = user.Claims.Where(f => f.Type == "Permission");

            if (!userRoles.Any(x => Claims.Contains(x.Value)) &&
                !userPermissions.Any(x => Claims.Contains(x.Value)))
            {
                context.Result = new ForbidResult();
                return;
            }

        }
    }
}
