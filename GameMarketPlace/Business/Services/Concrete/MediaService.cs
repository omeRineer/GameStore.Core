using Business.Services.Abstract;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Entities.Main;
using NET = Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Abstract;
using MassTransit;
using Entities.Enum.Type;
using Models.Media.WebService;

namespace Business.Services.Concrete
{
    public class MediaService : IMediaService
    {
        readonly IMediaRepository _mediaRepository;
        readonly NET.IHttpContextAccessor HttpContextAccessor;

        public MediaService(IMediaRepository mediaRepository, NET.IHttpContextAccessor httpContextAccessor)
        {
            _mediaRepository = mediaRepository;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> CreateAsync(Media media)
        {
            await _mediaRepository.AddAsync(media);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<Media>> GetSingleAsync(Guid id)
        {
            var entity = await _mediaRepository.GetSingleAsync(f => f.Id == id);

            return new SuccessDataResult<Media>(entity);
        }

        public async Task<IDataResult<List<Media>>> GetListByEntityAsync(Guid entityId, MediaTypeEnum? mediaType = null)
        {
            var result = await _mediaRepository.GetListAsync(f => f.EntityId == entityId);

            if (mediaType != null)
                result = result.Where(f => f.TypeId == (int)mediaType).ToList();

            return new SuccessDataResult<List<Media>>(result);
        }

        public async Task<IDataResult<List<Media>>> GetListByMediaTypeAsync(MediaTypeEnum mediaType)
        {
            var result = await _mediaRepository.GetListAsync(f => f.TypeId == (int)mediaType);

            return new SuccessDataResult<List<Media>>(result);
        }

        public async Task<IResult> UpdateAsync(Media media)
        {
            await _mediaRepository.UpdateAsync(media);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<Media?>> GetSingleByMediaTypeAsync(Guid entityId, MediaTypeEnum mediaType)
        {
            var media = await _mediaRepository.GetSingleOrDefaultAsync(f => f.EntityId == entityId && f.TypeId == (int)mediaType);

            return new SuccessDataResult<Media?>(media);
        }

        public async Task<IResult> AddAsync(Media media)
        {
            await _mediaRepository.AddAsync(media);

            return new SuccessResult();
        }

        public async Task<IResult> EditAsync(Media media)
        {
            await _mediaRepository.UpdateAsync(media);

            return new SuccessResult();
        }

        public async Task<IResult> RemoveAsync(Media media)
        {
            await _mediaRepository.DeleteAsync(media);

            return new SuccessResult();
        }

        public async Task<IResult> RemoveAsync(List<Media> mediaList)
        {
            await _mediaRepository.DeleteRangeAsync(mediaList);

            return new SuccessResult();
        }

        public async Task<IResult> UploadCollectionAsync(List<Media> mediaList)
        {
            await _mediaRepository.AddRangeAsync(mediaList);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UploadCollectionAsync(UploadMediaCollectionRequest uploadMediaCollectionRequest)
        {
            var entityList = uploadMediaCollectionRequest.Medias.Select(s => new Media
            {
                EntityId = uploadMediaCollectionRequest.EntityId,
                TypeId = uploadMediaCollectionRequest.MediaType,
                Node = s.Node,
                Name = s.Name
            }).ToList();

            await _mediaRepository.AddRangeAsync(entityList);
            await _mediaRepository.SaveAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<List<Media>>> GetListByEntitiesAsync(List<Guid> entityIdList)
        {
            var result = await _mediaRepository.GetListAsync(f => entityIdList.Contains(f.EntityId), includes: i => i.Include(x => x.Type));

            return new SuccessDataResult<List<Media>>(result);
        }
    }
}
