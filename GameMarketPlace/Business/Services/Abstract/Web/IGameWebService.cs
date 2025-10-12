using Core.Utilities.ResultTool;
using Models.Common;
using Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Web
{
    public interface IGameWebService
    {
        Task<IDataResult<GameResponse>> GetAsync(Guid id);
        Task<IDataResult<ListResponse<GameResponse>>> GetListAsync();
    }
}
