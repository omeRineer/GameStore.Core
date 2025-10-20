using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Models.Options
{
    public class TokenOptions
    {
        public TokenParams WebApi { get; set; }
        public TokenParams InternalApi { get; set; }
        public TokenParams ODataApi { get; set; }

        public class TokenParams
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public string SecurityKey { get; set; }
        }
    }

    
}
