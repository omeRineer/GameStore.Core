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
using Models.Media;

namespace Business.Services.Concrete
{
    public class GameService : IGameService
    {
        readonly IEfGameRepository _gameRepository;
        readonly IEfMediaRepository _mediaRepository;
        readonly IMapper _mapper;

        public GameService(IEfGameRepository gameRepository, IMapper mapper, IEfMediaRepository mediaRepository)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _mediaRepository = mediaRepository;
        }

        public async Task<IResult> CreateAsync(CreateGameRequest request)
        {
            var entity = _mapper.Map<Game>(request);
            entity.GenerateId();

            await _gameRepository.AddAsync(entity);
            if (request.CoverImage != null)
            {
                var coverImage = new Media
                {
                    Name = request.CoverImage.Name,
                    EntityId = entity.Id,
                    Url = request.CoverImage.Url,
                    TypeId = (int)MediaType.GameCoverImage
                };

                await _mediaRepository.AddAsync(coverImage);
            }
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id);
            var mediaList = await _mediaRepository.GetListAsync(f => f.EntityId == id);

            await _gameRepository.DeleteAsync(entity);
            await _mediaRepository.DeleteRangeAsync(mediaList);
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<SingleGameResponse>> GetAsync(Guid id)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == id, i => i.Include(x => x.Category));
            var mappedEntity = _mapper.Map<SingleGameResponse>(entity);

            var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == id && f.TypeId == (int)MediaType.GameCoverImage);
            if (coverImage != null)
                mappedEntity.CoverImage = _mapper.Map<GetMediaModel>(coverImage);

            return new SuccessDataResult<SingleGameResponse>(mappedEntity);
        }

        public async Task<IDataResult<GetGameImagesResponse>> GetImagesAsync(Guid id)
        {
            var images = await _mediaRepository.GetListAsync(f => f.EntityId == id && f.TypeId == (int)MediaType.GameImage);

            var result = new GetGameImagesResponse
            {
                Images = _mapper.Map<List<GetMediaModel>>(images)
            };

            return new SuccessDataResult<GetGameImagesResponse>(result);
        }

        public async Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest)
        {
            var entity = await _gameRepository.GetSingleAsync(f => f.Id == updateGameRequest.Id);
            var mappedEntity = _mapper.Map(updateGameRequest, entity);

            await _gameRepository.UpdateAsync(entity);
            if (updateGameRequest.CoverImage != null)
            {
                var coverImage = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == entity.Id && f.TypeId == (int)MediaType.GameCoverImage);

                // TODO Ömer : Burada resim dolu gelirse her seferinde güncelliyor. Versiyonlama yapılmalı
                if (coverImage != null)
                {
                    coverImage.Name = updateGameRequest.CoverImage.Name;
                    coverImage.Url = updateGameRequest.CoverImage.Url;
                    await _mediaRepository.UpdateAsync(coverImage);
                }
                else
                    await _mediaRepository.AddAsync(new Media
                    {
                        TypeId = (int)MediaType.GameCoverImage,
                        Name = updateGameRequest.CoverImage.Name,
                        EntityId = entity.Id,
                        Url = updateGameRequest.CoverImage.Url
                    });
            }
            await _gameRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UploadImagesAsync(UploadGameImagesRequest request)
        {
            var gameImages = await _mediaRepository.GetListAsync(f => f.EntityId == request.EntityId && f.TypeId == (int)MediaType.GameImage);
            var matchesResult = BusinessHelper.GetMatchesList(gameImages.Select(s => s.Name), request.Images.Select(s => s.Name));

            var removedImages = gameImages.Where(f => matchesResult.MisMatchesSource.Contains(f.Name));
            var newImages = matchesResult.MisMatchesCluster.Select(s => new Media
            {
                TypeId = (int)MediaType.GameImage,
                EntityId = request.EntityId,
                Url = request.Images.Single(f => f.Name == s).Url,
                Name = s
            });

            if (removedImages.Any()) await _mediaRepository.DeleteRangeAsync(removedImages);
            if (newImages.Any()) await _mediaRepository.AddRangeAsync(newImages);

            if (newImages.Any() || removedImages.Any())
                await _mediaRepository.SaveAsync();


            return new SuccessResult();
        }
    }
}
