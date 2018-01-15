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
        private bool paused = false;

        private DateTime lastStart;
        private double jTime = 0;
        private double jDistance = 0;

        private List<Position> secretRoute = new List<Position>();
        public ICommand ClickRecordStop { get; private set; }
        public ICommand ClickReset { get; private set; }


        public RecordDogWalkViewModel()
        {
            Initialize();
            ClickRecordStop = new Command(() =>
            {
                if (IsRecording)
                {
                    if (!paused)
                        Reset(true);

                    lastStart = DateTime.Now;
                    Device.StartTimer(TimeSpan.FromSeconds(2), RecordPoint);
                }
                paused = !IsRecording;
            });

            ClickReset = new Command(() =>
            {
                Reset(false);
            });
        }

        private void Reset(bool bRec)
        {
            routePoint = 0; paused = false; IsRecording = bRec; RoutePoints = new ObservableCollection<Position>(); jDistance = 0; jTime = 0; JourneyDistance = ""; JourneyTime = "";
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

        private bool RecordPoint()
        {
            if (paused || routePoint >= secretRoute.Count) return false;

            Position curPos = secretRoute[routePoint]; routePoint++;

            if (RoutePoints.Count > 0)
            {
                jDistance += PositionUtils.DistanceBetween(RoutePoints.Last(), curPos, Settings.UseMetric);
                TimeSpan ts = DateTime.Now - lastStart;
                jTime += ts.TotalSeconds;
                lastStart = DateTime.Now;
            }

            RoutePoints.Add(curPos);
            JourneyDistance = string.Format("{0:0.00} ", jDistance) + (Settings.UseMetric ? "km" : "mi");
            JourneyTime = TimeUtils.FormatSecMultiple(jTime);
            IsRecording = routePoint < secretRoute.Count;


            return IsRecording;
        }


        #region Attributes
        public ObservableCollection<Position> RoutePoints { get; set; } = new ObservableCollection<Position>();

        private bool _IsRecording = false;
        public bool IsRecording  { get { return _IsRecording; } set { if (_IsRecording == value) return; _IsRecording = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsNotRecording));} }
        public bool IsNotRecording { get { return !_IsRecording; } }


        private string _JourneyDistance = "";
        public string JourneyDistance { get { return _JourneyDistance; } set { if (_JourneyDistance == value) return; _JourneyDistance = value; OnPropertyChanged(); } }

        private string _JourneyTime = "";
        public string JourneyTime { get { return _JourneyTime; } set { if (_JourneyTime == value) return; _JourneyTime = value; OnPropertyChanged(); } }

        #endregion

    }
}
