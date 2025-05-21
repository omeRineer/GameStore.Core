using Business.Services.Abstract.Lookup;
using Core.Utilities.ResultTool;
using DataAccess.Concrete.EntityFramework.General.Lookup;
using Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Lookup
{
    public class LookupService : ILookupService
    {
        readonly IProcessGroupRepository _processGroupRepository;
        readonly IStatusLookupRepository _statusLookupRepository;
        readonly ITypeLookupRepository _typeLookupRepository;

        public LookupService(IProcessGroupRepository processGroupRepository, IStatusLookupRepository statusLookupRepository, ITypeLookupRepository typeLookupRepository)
        {
            _processGroupRepository = processGroupRepository;
            _statusLookupRepository = statusLookupRepository;
            _typeLookupRepository = typeLookupRepository;
        }

        public async Task<IDataResult<GetLookupsResponse>> GetProcessGroupsAsync()
        {
            var processGroups = await _processGroupRepository.GetListAsync();

            var result = new GetLookupsResponse
            {
                Items = processGroups.Select(s => new GetLookups_Item
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList()
            };

            return new SuccessDataResult<GetLookupsResponse>(result);
        }

        public async Task<IDataResult<GetLookupsResponse>> GetStatusesAsync(int processGroup)
        {
            var statuses = await _statusLookupRepository.GetListAsync(f=> f.ProcessGroupId == processGroup);

            var result = new GetLookupsResponse
            {
                Items = statuses.Select(s => new GetLookups_Item
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList()
            };

            return new SuccessDataResult<GetLookupsResponse>(result);
        }

        public async Task<IDataResult<GetLookupsResponse>> GetTypesAsync(int processGroup)
        {
            var types = await _typeLookupRepository.GetListAsync(f => f.ProcessGroupId == processGroup);

            var result = new GetLookupsResponse
            {
                Items = types.Select(s => new GetLookups_Item
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList()
            };

            return new SuccessDataResult<GetLookupsResponse>(result);
        }
    }
}
