using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace XDogApp.Utils
{
    public static class StringUtils
    {
        public static bool HasBlanks(params string[] prms)
        {
            bool ret = false;

            foreach (string s in prms)
                if (!String.IsNullOrWhiteSpace(s))
                {
                    ret = true;
                    break;
                }

            return ret;
        }

        public static bool IsValidEmail(string email)
        {
            return (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success);
        }
    }
}
