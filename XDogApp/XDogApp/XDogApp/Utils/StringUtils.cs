using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Utils
{
    public static class StringUtils
    {
        public static bool AreAllNullOrWhiteSpace(params string[] prms)
        {
            bool ret = true;

            foreach (string s in prms)
                if (!String.IsNullOrWhiteSpace(s))
                {
                    ret = false;
                    break;
                }

            return ret;
        }
    }
}
