using System;

namespace Models.Identity.Login
{
    public class UserLoginResponse
    {
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
    }
}
