using AutoMapper;
using Business.Services.Abstract.Web;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Web
{
    public class GameWebService : IGameWebService
    {
        readonly IEfGameRepository _gameRepository;
        readonly IMapper Mapper;

        public GameWebService(IEfGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            Mapper = mapper;
        }

        public async Task<IDataResult<GameDetailResponse>> GetAsync(Guid id)
        {
            var game = await _gameRepository.GetSingleOrDefaultAsync(f => f.Id == id, includes: i => i.Include(x=> x.Category).Include(x => x.Images));

            if (game == null)
                return new ErrorDataResult<GameDetailResponse>("Game is not found.");

            var result = Mapper.Map<GameDetailResponse>(game);

            return new SuccessDataResult<GameDetailResponse>(result);
        }

        public async Task<IDataResult<ListResponse<GameResponse>>> GetListAsync()
        {
            var data = await _gameRepository.GetListAsync(includes: i => i.Include(x => x.Category));

            var collection = Mapper.Map<List<GameResponse>>(data);

            var result = new ListResponse<GameResponse>(collection);

            return new SuccessDataResult<ListResponse<GameResponse>>(result);
        }
    }
}
