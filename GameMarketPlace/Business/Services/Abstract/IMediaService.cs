using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Enum.Type;
using Entities.Main;
using Models.Media.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IMediaService
    {
        Task<IResult> CreateAsync(Media media);
        Task<IResult> UploadCollectionAsync(List<Media> mediaList);
        Task<IResult> UploadCollectionAsync(UploadMediaCollectionRequest uploadMediaCollectionRequest);
        Task<IResult> UpdateAsync(Media media);

        Task<IResult> AddAsync(Media media);
        Task<IResult> EditAsync(Media media);
        Task<IResult> RemoveAsync(Media media);
        Task<IResult> RemoveAsync(List<Media> mediaList);

        Task<IDataResult<Media>> GetSingleAsync(Guid id);
        Task<IDataResult<Media?>> GetSingleByMediaTypeAsync(Guid entityId, MediaTypeEnum mediaType);
        Task<IDataResult<List<Media>>> GetListByEntityAsync(Guid entityId, MediaTypeEnum? mediaType = null);
        Task<IDataResult<List<Media>>> GetListByMediaTypeAsync(MediaTypeEnum mediaType);
        Task<IDataResult<List<Media>>> GetListByEntitiesAsync(List<Guid> entityIdList);
    }
}
