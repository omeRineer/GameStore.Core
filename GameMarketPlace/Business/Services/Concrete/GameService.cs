using AutoMapper;
using Business.Services.Abstract;
using Core.DataAccess;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entities.Enum.Type;
using Models.Game;
using Models.Blog;
using Business.Helpers;
using MeArch.Module.Security.Entities.Master;
using DataAccess.Concrete.EntityFramework.General.Identity;
using Models.Common;

namespace Business.Services.Concrete
{
    public class GameService : IGameManagementService
    {
        readonly IEfGameRepository _gameRepository;
        readonly IEfGameImageRepository _gameImageRepository;
        readonly IMapper _mapper;

        public GameService(IEfGameRepository gameRepository, IMapper mapper, IEfGameImageRepository gameImageRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _gameImageRepository = gameImageRepository;
        }

        public async Task<IResult> CreateAsync(CreateGameRequest request)
        {
            var entity = _mapper.Map<Game>(request);
            entity.GenerateId();

            await _gameRepository.AddAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id);

            await _gameRepository.DeleteAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<GameResponse>> GetAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id, i => i.Include(x => x.Category));
            var mappedEntity = _mapper.Map<GameResponse>(entity);

            return new SuccessDataResult<GameResponse>(mappedEntity);
        }

        public async Task<IDataResult<ListResponse<GameImageResponse>>> GetImagesAsync(Guid id)
        {
            var images = await _gameImageRepository.GetListAsync(f => f.GameId == id);

            var mappedImages = _mapper.Map<List<GameImageResponse>>(images);

            var result = new ListResponse<GameImageResponse>(mappedImages);

            return new SuccessDataResult<ListResponse<GameImageResponse>>(result);
        }

        public async Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == updateGameRequest.Id);
            var mappedEntity = _mapper.Map(updateGameRequest, entity);

            await _gameRepository.UpdateAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UploadImagesAsync(UploadGameImagesRequest request)
        {
            var newImages = request.Images.Select(s => new GameImage
            {
                GameId = request.EntityId,
                Name = s.Name,
                Url = s.Url,
                Priority = s.Priority
            });

            await _gameImageRepository.AddRangeAsync(newImages);
            await _gameRepository.SaveAsync();

            return new SuccessResult("Upload is successful");
        }
    }
}
