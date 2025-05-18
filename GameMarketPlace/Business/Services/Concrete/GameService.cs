using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
using Core.Business.BaseService;
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
using MassTransit;
using Entities.Enum.Type;
using Models.Game.WebService;
using Models.Category.WebService;
using Models.Blog.WebService;

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IMediaService _mediaService;
        readonly IGameRepository _gameRepository;
        readonly NET.IHttpContextAccessor HttpContextAccessor;
        readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper, NET.IHttpContextAccessor httpContextAccessor, IMediaService mediaService)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
            _mediaService = mediaService;
        }

        public async Task<IResult> CreateAsync(CreateGameRequest request)
        {
            var entity = _mapper.Map<Game>(request);
            entity.GenerateId();

            await _gameRepository.AddAsync(entity);
            await _mediaService.AddAsync(new Media
            {
                EntityId = entity.Id,
                TypeId = (int)MediaTypeEnum.GameCoverImage,
                Node = request.CoverImage.Node,
                Name = request.CoverImage.Name
            });
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id);
            var medias = await _mediaService.GetListByEntityAsync(id);

            await _mediaService.RemoveAsync(medias.Data);
            await _gameRepository.DeleteAsync(entity);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleGameResponse>> GetAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id, i => i.Include(x => x.Category));
            var mappedEntity = _mapper.Map<SingleGameResponse>(entity);

            var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaTypeEnum.GameCoverImage);
            if (coverImage.Data != null)
                mappedEntity.CoverImage = new MA.File { Node = coverImage.Data.Node, Name = coverImage.Data.Name };

            return new SuccessDataResult<SingleGameResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == updateGameRequest.Id);
            var mappedEntity = _mapper.Map(updateGameRequest, entity);

            await _gameRepository.UpdateAsync(entity);
            if (updateGameRequest.CoverImage != null)
            {
                var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaTypeEnum.GameCoverImage);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage.Data != null)
                {
                    coverImage.Data.Name = updateGameRequest.CoverImage.Name;
                    coverImage.Data.Node = updateGameRequest.CoverImage.Node;
                    await _mediaService.EditAsync(coverImage.Data);
                }
                else
                    await _mediaService.AddAsync(new Media
                    {
                        TypeId = (int)MediaTypeEnum.GameCoverImage,
                        Node = updateGameRequest.CoverImage.Node,
                        Name = updateGameRequest.CoverImage.Name,
                        EntityId = entity.Id
                    });
            }
            await _gameRepository.SaveAsync();

            

            return new SuccessResult();
        }

    }
}
