﻿#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XDogApp.Helpers;
using XDogApp.Models;
using XDogApp.ServiceData;
using XDogApp.Services;
using XDogApp.Views;

namespace XDogApp
{
    public partial class App : Application
    {
        //SV ADDED
        public static double ScreenHeight;
        public static double ScreenWidth;

        public App()
        {

            InitializeComponent();

            AppResources.AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;

            if (PCL_AppConstants.bUseMockDataStore)
            {
                DependencyService.Register<MockDataStore<TodoItem>>();
                DependencyService.Register<MockDataStore<Dog>>();
                DependencyService.Register<MockDataStore<DogOwner>>();
                DependencyService.Register<MockDataStore<Address>>();
                DependencyService.Register<MockDataStore<Business>>();
            }
            else
            {
                DependencyService.Register<AzureDataStore<TodoItem>>();
                DependencyService.Register<DataStore<TodoItem>>();
                DependencyService.Register<DataStore<Dog>>();
                DependencyService.Register<DataStore<DogOwner>>();
                DependencyService.Register<DataStore<Address>>();
                DependencyService.Register<DataStore<Business>>();
            }


            //MainPage = (Device.RuntimePlatform == Device.iOS ? getStartPage() : new NavigationPage(getStartPage()));
            MainPage = getStartPage();
        }

        private Page getStartPage()
        {
            Page ret;

            // test TODO remove later
            return new Menu.MDMainPage();
            //return new Menu.MainMenu();


            if (!string.IsNullOrEmpty(Settings.Token) && !string.IsNullOrEmpty(Settings.ScreenName))     // logged in, so start
                ret = new MainPage();
            else if (!string.IsNullOrEmpty(Settings.Token) && string.IsNullOrEmpty(Settings.ScreenName)) // registered but no profile
                ret = new DogOwnerPage();
            else if (!string.IsNullOrEmpty(Settings.Email) && !string.IsNullOrEmpty(Settings.Password))  // has login/password but not logged in
                ret = new LoginPage();
            else                                                                                         // never been here before
                ret = new RegisterPage();

            return ret;
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
