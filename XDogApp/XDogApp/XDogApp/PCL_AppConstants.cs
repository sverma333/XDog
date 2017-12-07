using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp
{
    public static class PCL_AppConstants
    {
        public static bool bUseMockDataStore = false;
        public static bool bUseTestASPNetServer = true;
        public static bool bLogSqlLite = false;

        public static string sLocalURL = "http://localhost:62836";
        public static string sMobileApplURL = "http://xdogservice.azurewebsites.net";

        public static string sCurrentServiceURL = (bUseTestASPNetServer ? sLocalURL : sMobileApplURL);
    }
}
