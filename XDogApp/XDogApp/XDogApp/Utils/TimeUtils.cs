using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Utils
{
    public static class TimeUtils
    {
        public static string FormatSec(double s, string fmt=@"hh\:mm\:ss")
        {   // fmt = @"hh\:mm\:ss\:fff", @"hh hr mm min ss sec"
            return TimeSpan.FromSeconds(s).ToString(fmt);
        }

        public static string FormatSecMultiple(double s, string fmt1="hh", string fmt2="mm", string fmt3=@"ss")
        {
            string ret = "";
            TimeSpan ts = TimeSpan.FromSeconds(s);
            if (ts.TotalSeconds > 0)
            {
                if (ts.Hours > 0) ret += ts.ToString(fmt1) + "hr ";
                if (ts.Minutes > 0) ret += ts.ToString(fmt2) + " m ";
                if (ts.Seconds > 0) ret += ts.ToString(fmt3) + " s ";
            }
            else
                ret = "0 s ";


            return ret;
        }
    }
}
