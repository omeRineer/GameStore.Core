using AutoMapper;
using Business.Services.Abstract.Identity;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Identity;
using MeArch.Module.Security.Model.Dto;
using Models.Identity.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Identity
{
    public class ProfileService : IProfileService
    {
        readonly IEfUserRepository _userRepository;
        readonly CurrentUser CurrentUser;
        readonly IMapper _mapper;

        public ProfileService(CurrentUser currentUser, IMapper mapper, IEfUserRepository userRepository)
        {
            CurrentUser = currentUser;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IDataResult<GetProfileResponse>> GetAsync()
        {
            var user = await _userRepository.GetSingleAsync(f=> f.Id == CurrentUser.Id);

            var result = _mapper.Map<GetProfileResponse>(user);

            return new SuccessDataResult<GetProfileResponse>(result);
        }

        public async Task<IResult> UpdateAsync(UpdateProfileRequest request)
        {
            var user = await _userRepository.GetSingleAsync(f => f.Id == CurrentUser.Id);

            if ((DateTime.Now - user.EditDate).Days < 15)
                return new ErrorResult("Hesap bilgileri 15 gün içeriside bir kez değiştirilebilir");

            var editUser = _mapper.Map(request, user);

            await _userRepository.UpdateAsync(editUser);
            await _userRepository.SaveAsync();

            return new SuccessResult();
        }
    }
}
