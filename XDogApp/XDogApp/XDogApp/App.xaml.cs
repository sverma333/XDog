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
        //SV Added
        public static bool bUseMockDataStore = false;
        public static bool bUseTestASPNetServer = false;

        public static string sAzureMobileAppUrl = (bUseTestASPNetServer ? "http://localhost:51544/" : "http://xdogserver.azurewebsites.net");

        //public static MobileServiceClient MobileService = new MobileServiceClient(sAzureMobileAppUrl);
        //public static MobileServiceSQLiteStore SQLiteStore = new MobileServiceSQLiteStore("app1.db");

        public App()
        {

            InitializeComponent();

            if (bUseMockDataStore)
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
