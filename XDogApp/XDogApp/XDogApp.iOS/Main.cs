using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.WindowsAzure.MobileServices;

namespace XDogApp.iOS
{
    public class Application
    {
        //SV Added
        //public static MobileServiceClient MobileService = new MobileServiceClient("https://xdogserver.azurewebsites.net");

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            //SV Added
            AppCenter.Start("fd3b9965-2833-481b-a812-3cb085f66bc8", typeof(Analytics), typeof(Crashes));



            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
