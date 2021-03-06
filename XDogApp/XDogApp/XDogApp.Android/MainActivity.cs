﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Media;
using Plugin.MediaManager.Forms.Android;
//using NativeCode.Mobile.AppCompat.FormsAppCompat;
using Xamarin.Forms;

namespace XDogApp.Droid
{
    [Activity(Label = "XDogApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    //public class MainActivity : AppCompatFormsApplicationActivity
    {
        //SV Added
        //public static MobileServiceClient MobileService = new MobileServiceClient("https://xdogserver.azurewebsites.net");

        protected override async void OnCreate(Bundle bundle)
        {
            AppCenter.Start("fd3b9965-2833-481b-a812-3cb085f66bc8", typeof(Analytics), typeof(Crashes));

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            #region SV ADDED Init

            VideoViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            var width = Resources.DisplayMetrics.WidthPixels;
			var height = Resources.DisplayMetrics.HeightPixels;
			var density = Resources.DisplayMetrics.Density;

			App.ScreenWidth = (width - 0.5f) / density;
			App.ScreenHeight = (height - 0.5f) / density;

            #endregion

            LoadApplication(new App());
        }
    }
}

