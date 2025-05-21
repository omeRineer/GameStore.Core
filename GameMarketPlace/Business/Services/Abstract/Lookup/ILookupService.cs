using Core.Utilities.ResultTool;
using Models.Lookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract.Lookup
{
    public interface ILookupService
    {
        Task<IDataResult<GetLookupsResponse>> GetProcessGroupsAsync();
        Task<IDataResult<GetLookupsResponse>> GetTypesAsync(int processGroup);
        Task<IDataResult<GetLookupsResponse>> GetStatusesAsync(int processGroup);
    }
}
