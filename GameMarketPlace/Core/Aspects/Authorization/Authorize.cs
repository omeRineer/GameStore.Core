﻿using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using Core.Utilities.ServiceTools;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Authorizaton
{
    public class Authorize : InterceptorAspect
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Authorize(params string[] roles)
        {
            _roles = roles;
            _httpContextAccessor = StaticServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var userClaims = _httpContextAccessor.HttpContext.User.Claims;
            foreach (var role in _roles)
            {
                foreach (var userClaim in userClaims)
                {
                    if (userClaim.Value == role)
                    {
                        return;
                    }
                }
            }

            throw new Exception("Authorization Exception");

        }
    }
}
