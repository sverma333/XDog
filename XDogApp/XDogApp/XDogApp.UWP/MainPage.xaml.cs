using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XDogApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("RvxeQMWODHqpsn0ES2lf~LiFAvb1keNQD1MTzl8u_OQ~Ah87p8ShFvCIttHh6gp95TCD_mwEObtjAn9KTOCDtbIgUMZUsg3LSgCWb-EpjgW1");
            LoadApplication(new XDogApp.App());
        }
    }
}
