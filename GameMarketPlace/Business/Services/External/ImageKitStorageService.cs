using Core.Utilities.ResultTool;
using Imagekit.Models;
using Imagekit.Sdk;
using MailKit.Search;
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

        public async Task<IDataResult<ResultList>> GetListAsync(string? tags)
        {
            StringBuilder tagsBuilder = null;
            if(tags != null)
            {
                tagsBuilder = new StringBuilder();
                var tagList = tags.Split(',');
                tagsBuilder.Append("[");
                foreach (var tag in tagList)
                {
                    if (tag == tagList[tagList.Length - 1])
                        tagsBuilder.Append($"'{tag}'");
                    else
                        tagsBuilder.Append($"'{tag}',");
                }
                tagsBuilder.Append("]");
            }

            var request = new GetFileListRequest();
            if (tagsBuilder != null)
                request.SearchQuery = $"tags IN {tagsBuilder.ToString()}";

            var result = await ImagekitClient.GetFileListRequestAsync(request);

            return new SuccessDataResult<ResultList>(result);
        }
    }
}
