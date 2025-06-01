using AutoMapper;
using Business.Services.Abstract;
using MA = Core.Entities.DTO.File;
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

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IEfGameRepository _gameRepository;
        readonly NET.IHttpContextAccessor HttpContextAccessor;
        readonly IMapper _mapper;

        public GameService(IEfGameRepository gameRepository, IMapper mapper, NET.IHttpContextAccessor httpContextAccessor)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> CreateAsync(CreateGameRequest request)
        {
            var entity = _mapper.Map<Game>(request);
            entity.GenerateId();

            await _gameRepository.AddAsync(entity);
            //await _mediaService.AddAsync(new Media
            //{
            //    EntityId = entity.Id,
            //    TypeId = (int)MediaType.GameCoverImage,
            //    Node = request.CoverImage.Node,
            //    Name = request.CoverImage.Name
            //});
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

        public async Task<IDataResult<SingleGameResponse>> GetAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id, i => i.Include(x => x.Category));
            var mappedEntity = _mapper.Map<SingleGameResponse>(entity);

            //var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaType.GameCoverImage);
            //if (coverImage.Data != null)
            //    mappedEntity.CoverImage = new MA.File { Node = coverImage.Data.Node, Name = coverImage.Data.Name };

            return new SuccessDataResult<SingleGameResponse>(mappedEntity);
        }

        public async Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == updateGameRequest.Id);
            var mappedEntity = _mapper.Map(updateGameRequest, entity);

            await _gameRepository.UpdateAsync(entity);
            //if (updateGameRequest.CoverImage != null)
            //{
            //    var coverImage = await _mediaService.GetSingleByMediaTypeAsync(entity.Id, MediaType.GameCoverImage);

            //    // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
            //    if (coverImage.Data != null)
            //    {
            //        coverImage.Data.Name = updateGameRequest.CoverImage.Name;
            //        coverImage.Data.Node = updateGameRequest.CoverImage.Node;
            //        await _mediaService.EditAsync(coverImage.Data);
            //    }
            //    else
            //        await _mediaService.AddAsync(new Media
            //        {
            //            TypeId = (int)MediaType.GameCoverImage,
            //            Node = updateGameRequest.CoverImage.Node,
            //            Name = updateGameRequest.CoverImage.Name,
            //            EntityId = entity.Id
            //        });
            //}
            await _gameRepository.SaveAsync();

            

            return new SuccessResult();
        }

    }
}
