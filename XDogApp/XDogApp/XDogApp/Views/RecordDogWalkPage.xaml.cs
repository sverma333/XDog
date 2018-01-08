using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using XDogApp.Models;
using XDogApp.Utils;
using XDogApp.ViewModels;

namespace XDogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordDogWalkPage : ContentPage
    {
        //int RunNumber = 0;
        //bool shouldRun = true;

        //public void RefreshLocalData()
        //{
        //    Device.StartTimer(TimeSpan.FromSeconds(3), SendReadConfirmationAsync);
        //}


        //public bool SendReadConfirmationAsync()
        //{
        //    RunNumber++;
        //    SeedData();

        //    return RunNumber < 20;
        //}

        public RecordDogWalkPage()
        {
            InitializeComponent();
            //RefreshLocalData();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.iOS)
            {
                App.ScreenWidth = width;
                App.ScreenHeight = height;
            }
        }

        //private void SeedData()
        //{
        //    Random r = new Random();
        //    customMap.RouteCoordinates.Clear();
        //    int iThreshold = 8;

        //    if (r.Next(10) > 0) customMap.RouteCoordinates.Add(new Position(37.797534, -122.401827));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.797510, -122.402060));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.790269, -122.400589));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.790265, -122.400474));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.790228, -122.400391));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.790126, -122.400360));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.789250, -122.401451));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.788440, -122.400396));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.787999, -122.399780));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.786736, -122.398202));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.786345, -122.397722));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.785983, -122.397295));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
        //    if (r.Next(10) > iThreshold) customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
        //    if (r.Next(10) > 0) customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));

        //    if (RunNumber == 1)
        //    {
        //        customMap.Pins.Add(new Pin() { Position = new Position(37.797534, -122.401827), Label = "Starting Point" });
        //        customMap.Pins.Add(new Pin() { Position = new Position(37.776831, -122.394627), Label = "Ending Point" });
        //    }

        //    customMap.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (37.786345, -122.397722), Distance.FromMiles (2.0)));
        //}

    }
}