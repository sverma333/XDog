#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XDogApp.Models;
using XDogApp.Services;

namespace XDogApp
{
    public partial class App : Application
    {

        public static string sAzureMobileAppUrl = (PCL_AppConstants.bUseTestASPNetServer ? "http://localhost:51544/" : "http://xdogserver.azurewebsites.net");

        public App()
        {

            InitializeComponent();

            if (PCL_AppConstants.bUseMockDataStore)
                DependencyService.Register<MockDataStore<TodoItem>>();
            else
                DependencyService.Register<AzureDataStore<TodoItem>>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new XDogApp.Views.RegisterPage();
//            MainPage = new NavigationPage(new MainPage());

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
