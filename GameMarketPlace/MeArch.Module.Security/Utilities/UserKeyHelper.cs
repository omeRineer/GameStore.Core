using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeArch.Module.Security.Utilities
{
    public class UserKeyHelper
    {
        private static readonly Random _random = new();

        public static string GenerateUserKey(string prefix, int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[_random.Next(chars.Length)]);
            }

            return $"{prefix}{sb}";
        }
    }
}
