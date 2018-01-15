using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XDogApp.Utils
{
    public static class PageUtils
    {
        public static void RecordWidthHeight(double width, double height)
        {
            if (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.iOS)
            {
                App.ScreenHeight = height;
                App.ScreenWidth = width;
            }
        }
    }
}
