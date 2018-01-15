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

namespace XDogApp.ViewModels
{
    class OpeningViewModel : BaseViewModel
    {
        public ICommand CloseTappedCommand { get; set; }
        public ICommand SlideOpenCommand { get; set; }

        public OpeningViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            IsSlide = false;
            DefaultHeight = App.ScreenHeight;
            DefaultWidth = App.ScreenWidth;

            CloseTappedCommand =  new Command(()=> {IsSlide = false;});
            SlideOpenCommand =  new Command(()=> {IsSlide = !IsSlide;});
        }

        #region Attributes
        private double _DefaultHeight = 0;
        public double DefaultHeight { get { return _DefaultHeight; } set { if (Math.Abs(_DefaultHeight - value) < Double.Epsilon) return; _DefaultHeight = value; OnPropertyChanged(); } }

        private double _DefaultWidth = 0;
        public double DefaultWidth { get { return _DefaultWidth; } set { if (Math.Abs(_DefaultWidth - value) < Double.Epsilon) return; _DefaultWidth = value; OnPropertyChanged(); } }

        private bool _IsSlide = false;
        public bool IsSlide { get { return _IsSlide; } set { if (_IsSlide == value) return; _IsSlide = value; OnPropertyChanged(); } }
        #endregion

    }
}
