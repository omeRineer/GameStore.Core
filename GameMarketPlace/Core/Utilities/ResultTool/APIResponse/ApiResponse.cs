using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.ResultTool.APIResponse
{
    public class ApiResponse
    {
        public ApiResponse() : this(true, null)
        {

        }
        public ApiResponse(string message) : this(true, message)
        {

        }
        public ApiResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string? Message { get; }
    }

    public class ApiDataResponse<TData> : ApiResponse
    {
        public ApiDataResponse(TData data) : this(true, null, data)
        {

        }
        public ApiDataResponse(string message, TData data) : this(true, message, data)
        {

        }
        public ApiDataResponse(bool isSuccess, string message, TData data) : base(isSuccess, message)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}
