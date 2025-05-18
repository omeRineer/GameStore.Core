using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using MeArch.Module.Security.Model.UserIdentity;
using MeArch.Module.Security.Service;
using Models.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        readonly IUserRepository _userRepository;
        readonly ITokenService _tokenService;
        readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserLoginResponse>> LoginAsync(UserLoginRequest request)
        {
            var user = await _userRepository.GetByUserNameAndPassword(request.UserName, request.Password);

            if (user == null)
                return new ErrorDataResult<UserLoginResponse>();


            var roles = user.UserRoles?.Select(s => s.Role).ToList();

            var permissions = new List<Permission>();

            var rolePermissions = roles.SelectMany(s => s.RolePermissions).Select(s => s.Permission).ToList();
            if (rolePermissions != null && rolePermissions.Count > 0)
                permissions.AddRange(rolePermissions);

            var userPermissions = user.UserPermissions?.Select(s => s.Permission).ToList();
            if (userPermissions != null && userPermissions.Count > 0)
                permissions.AddRange(userPermissions);

            var token = _tokenService.GenerateToken(user, roles, permissions);

            var result = new UserLoginResponse
            {
                Token = token.Token,
                ExpireDate = token.ExpireDate
            };

            return new SuccessDataResult<UserLoginResponse>(result);
        }
    }
}
