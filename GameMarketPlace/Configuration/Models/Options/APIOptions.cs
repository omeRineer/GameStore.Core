using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Models.Options
{
    public class APIOptions
    {
        public ApiParams WebApi { get; set; }
        public ApiParams ODataApi { get; set; }
        public ApiParams InternalApi { get; set; }
        public ApiParams IdentityApi { get; set; }
        public ApiParams MetaApi { get; set; }

        public class ApiParams
        {
            public string ApiUrl { get; set; }
            public string BaseUrl { get; set; }
        }
    }
}
