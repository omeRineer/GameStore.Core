using AutoMapper;
using Business.Helpers;
using Business.Services.Abstract;
using Business.Services.Abstract.Identity;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using Entities.Main;
using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Entities.Menu;
using MeArch.Module.Security.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Models.Category;
using Models.Identity.Menu;
using Models.Identity.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class MenuService : IMenuService
    {
        readonly CurrentUser CurrentUser;
        readonly IEfMenuRepository _menuRepository;
        readonly IEfMenuPermissionRepository _menuPermissionRepository;
        readonly IMapper _mapper;
        readonly IEfUserRepository _userRepository;

        public MenuService(IMapper mapper, IEfMenuRepository menuRepository, IEfMenuPermissionRepository menuPermissionRepository, CurrentUser currentUser, IEfUserRepository userRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            _menuPermissionRepository = menuPermissionRepository;
            CurrentUser = currentUser;
            _userRepository = userRepository;
        }

        public async Task<IResult> CreateAsync(CreateMenuRequest request)
        {
            var entity = _mapper.Map<Menu>(request);

            await _menuRepository.AddAsync(entity);
            await _menuRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _menuRepository.DeleteAsync(id);
            await _menuRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleMenuResponse>> GetAsync(Guid id)
        {
            var entity = await _menuRepository.GetSingleAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<SingleMenuResponse>(entity);

            return new SuccessDataResult<SingleMenuResponse>(mappedEntity);
        }

        public async Task<IDataResult<GetMenusResponse>> GetListAsync()
        {
            var menuList = await _menuRepository.GetListAsync();

            var result = new GetMenusResponse
            {
                Menus = menuList.Select(s => new GetMenus_Item
                {
                    Id = s.Id,
                    Code = s.Code,
                    Icon = s.Icon,
                    ParentMenuId = s.ParentMenuId,
                    Path = s.Path,
                    Priority = s.Priority,
                    Title = s.Title
                }).ToList()
            };

            return new SuccessDataResult<GetMenusResponse>(result);
        }

        public async Task<IDataResult<GetMenuPermissionsResponse>> GetPermissionsAsync(Guid id)
        {
            var menuPermissions = await _menuPermissionRepository.GetListAsync(f => f.MenuId == id);

            var result = new GetMenuPermissionsResponse
            {
                Permissions = menuPermissions.Select(s => s.PermissionId).ToList()
            };

            return new SuccessDataResult<GetMenuPermissionsResponse>(result);
        }

        public async Task<IDataResult<GetMenusResponse>> GetSessionMenusAsync()
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == CurrentUser.Id, i => i.Include(x => x.UserRoles).ThenInclude(x => x.Role).ThenInclude(x => x.RolePermissions).Include(x => x.UserPermissions));
            var userRoles = user.UserRoles.Select(s => s.RoleId);

            var userPermissions = new List<Guid>();

            if (user.UserPermissions != null)
                userPermissions.AddRange(user.UserPermissions.Select(s => s.PermissionId));

            if (user.UserRoles.SelectMany(s => s.Role.RolePermissions) != null)
                userPermissions.AddRange(user.UserRoles.SelectMany(s => s.Role.RolePermissions).Select(s => s.PermissionId));

            var menuList = await _menuRepository.GetListAsync(f => f.Permissions.Any(x => userPermissions.Contains(x.PermissionId)),
                                                              includes: i => i.Include(x => x.Permissions));
            var result = new GetMenusResponse
            {
                Menus = menuList.Select(s => new GetMenus_Item
                {
                    Id = s.Id,
                    ParentMenuId = s.ParentMenuId,
                    Title = s.Title,
                    Code = s.Code,
                    Icon = s.Icon,
                    Path = s.Path,
                    Priority = s.Priority
                }).ToList()
            };

            return new SuccessDataResult<GetMenusResponse>(result);
        }

        public async Task<IResult> SetPermissionsAsync(SetMenuPermissionsRequest request)
        {
            var menuPermissions = await _menuPermissionRepository.GetListAsync(f => f.MenuId == request.MenuId);
            var matchesResult = BusinessHelper.GetMatchesList(menuPermissions.Select(s => s.PermissionId), request.Permissions);

            var removedMenuPermissions = menuPermissions.Where(f => matchesResult.MisMatchesSource.Contains(f.PermissionId));
            var newMenuPermissions = matchesResult.MisMatchesCluster.Select(s => new MenuPermission
            {
                PermissionId = s,
                MenuId = request.MenuId
            });

            if (removedMenuPermissions.Any()) await _menuPermissionRepository.DeleteRangeAsync(removedMenuPermissions);
            if (newMenuPermissions.Any()) await _menuPermissionRepository.AddRangeAsync(newMenuPermissions);

            if (newMenuPermissions.Any() || removedMenuPermissions.Any())
                await _menuPermissionRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(UpdateMenuRequest request)
        {
            var entity = await _menuRepository.GetSingleAsync(f => f.Id == request.Id);
            var mappedEntity = _mapper.Map(request, entity);

            await _menuRepository.UpdateAsync(entity);
            await _menuRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
