using Core.Utilities.ResultTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IPermissionService
    {
        Task<IResult> UploadCollectionAsync(string[] permissions);
    }
}
