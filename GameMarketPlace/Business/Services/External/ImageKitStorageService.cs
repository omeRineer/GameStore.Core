using Core.Utilities.ResultTool;
using Imagekit.Models;
using Imagekit.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.External
{
    public class ImageKitStorageService
    {
        readonly ImagekitClient ImagekitClient;
        public ImageKitStorageService(ImagekitClient imagekitClient)
        {
            ImagekitClient = imagekitClient;
        }

        public async Task<IDataResult<ResultList>> GetListAsync(string? tag)
        {
            var result = await ImagekitClient.GetFileListRequestAsync(new GetFileListRequest
            {
                Tags = new string[] { tag }
            });

            return new SuccessDataResult<ResultList>(result);
        }
    }
}
