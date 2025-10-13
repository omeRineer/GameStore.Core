using Core.Utilities.ResultTool;
using Entities.Main;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Models.Game;
using Models.GameImage;
using Models.Common;


namespace Business.Services.Abstract
{
    public interface IGameManagementService
    {
        Task<IDataResult<GameResponse>> GetAsync(Guid id);
        Task<IResult> CreateAsync(CreateGameRequest request);
        Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> UploadImagesAsync(UploadGameImagesRequest request);
        Task<IDataResult<ListResponse<GameImageResponse>>> GetImagesAsync(Guid id);
    }
}
