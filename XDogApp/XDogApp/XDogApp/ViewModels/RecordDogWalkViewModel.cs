using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XDogApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using XDogApp;

using XDogApp.Services;
using XDogApp.Helpers;
using XDogApp.ServiceData;
using Plugin.Media;
using Plugin.Media.Abstractions;
using XDogApp.Utils;
using Plugin.MediaManager;
using PCLStorage;
using System.IO;
using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace XDogApp.ViewModels
{

    class RecordDogWalkViewModel : BaseViewModel
    { 
        private int routePoint = 0;
        private List<Position> secretRoute = new List<Position>();

        public RecordDogWalkViewModel()
        {
            Initialize();

            Device.StartTimer(TimeSpan.FromSeconds(2), SeedData);
        }

        private void Initialize()
        {
            secretRoute.Add(new Position(37.797534, -122.401827));
            secretRoute.Add(new Position(37.797510, -122.402060));
            secretRoute.Add(new Position(37.790269, -122.400589));
            secretRoute.Add(new Position(37.790265, -122.400474));
            secretRoute.Add(new Position(37.790228, -122.400391));
            secretRoute.Add(new Position(37.790126, -122.400360));
            secretRoute.Add(new Position(37.789250, -122.401451));
            secretRoute.Add(new Position(37.788440, -122.400396));
            secretRoute.Add(new Position(37.787999, -122.399780));
            secretRoute.Add(new Position(37.786736, -122.398202));
            secretRoute.Add(new Position(37.786345, -122.397722));
            secretRoute.Add(new Position(37.785983, -122.397295));
            secretRoute.Add(new Position(37.785559, -122.396728));
            secretRoute.Add(new Position(37.780624, -122.390541));
            secretRoute.Add(new Position(37.777113, -122.394983));
            secretRoute.Add(new Position(37.776831, -122.394627));
        }

        private bool SeedData()
        {
            RoutePoints.Add(secretRoute[routePoint++]);
            IsRecording =  routePoint < secretRoute.Count;

            return IsRecording;
        }


        #region Attributes
        public ObservableCollection<Position> RoutePoints { get; set; } = new ObservableCollection<Position>();

        private bool _IsRecordinge = false;
        public bool IsRecording  { get { return _IsRecordinge; } set { if (_IsRecordinge == value) return; _IsRecordinge = value; OnPropertyChanged(); } }

        #endregion

    }
}
