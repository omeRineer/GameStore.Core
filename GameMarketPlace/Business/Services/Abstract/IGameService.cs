using Core.Business;
using Core.Utilities.ResultTool;
using Entities.Main;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Models.Game;


namespace Business.Services.Abstract
{
    public interface IGameService
    {
        Task<IDataResult<SingleGameResponse>> GetAsync(Guid id);
        Task<IResult> CreateAsync(CreateGameRequest request);
        Task<IResult> UpdateAsync(UpdateGameRequest updateGameRequest);
        Task<IResult> DeleteAsync(Guid id);
    }
}
