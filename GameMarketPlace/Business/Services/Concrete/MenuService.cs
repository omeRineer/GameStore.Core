using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using Entities.Main;
using MeArch.Module.Security.Entities.Master;
using MeArch.Module.Security.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Models.Category;
using Models.Identity.Menu;
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
        readonly IMapper _mapper;

        public MenuService(IMapper mapper, IEfMenuRepository menuRepository, CurrentUser currentUser)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
            CurrentUser = currentUser;
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

        public async Task<IDataResult<MenuResponse>> GetAsync(Guid id)
        {
            var entity = await _menuRepository.GetSingleAsync(f => f.Id == id);
            var mappedEntity = _mapper.Map<MenuResponse>(entity);

            return new SuccessDataResult<MenuResponse>(mappedEntity);
        }

        public async Task<IDataResult<GetMenusResponse>> GetListAsync()
        {
            var menuList = await _menuRepository.GetListAsync();

            var result = new GetMenusResponse
            {
                Menus = menuList.Select(s => new MenuResponse
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


        public async Task<IDataResult<GetMenusResponse>> GetSessionMenusAsync()
        {
            var menuList = await _menuRepository.GetListAsync(f => CurrentUser.Permissions.Contains(f.Permission) || string.IsNullOrEmpty(f.Permission));
            var result = new GetMenusResponse
            {
                Menus = menuList.Select(s => new MenuResponse
                {
                    Id = s.Id,
                    ParentMenuId = s.ParentMenuId,
                    Title = s.Title,
                    Code = s.Code,
                    Icon = s.Icon,
                    Path = s.Path,
                    Priority = s.Priority,
                    Permission = s.Permission
                }).ToList()
            };

            return new SuccessDataResult<GetMenusResponse>(result);
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
