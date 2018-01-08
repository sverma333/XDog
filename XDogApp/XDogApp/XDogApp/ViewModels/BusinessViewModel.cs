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

namespace XDogApp.ViewModels
{
    class BusinessViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }

        public BusinessViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Business>>() ?? new MockDataStore<Business>();
            DataStore.InitializeAsync();

            
            ClickCreate = new Command(async () =>
            {
                Business item = new Business { Name = this.BusinessName, Type = this.BusinessType, Bio = this.BusinessBio, OpeningTimes = this.BusinessOpeningTimes, DOB = Convert.ToDateTime(this.BusinessDOB) };

                bool res = await DataStore.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successfully Saved" : "Failed to Save");

            });
        }


        #region Attributes
        private string _BusinessName = "";
        public string BusinessName { get { return _BusinessName; } set { if (_BusinessName == value) return; _BusinessName = value; OnPropertyChanged(); }}

        private string _BusinessType = "";
        public string BusinessType { get { return _BusinessType; } set { if (_BusinessType == value) return; _BusinessType = value; OnPropertyChanged(); }}


        private string _BusinessBio = "";
        public string BusinessBio { get { return _BusinessBio; } set { if (_BusinessBio == value) return; _BusinessBio = value; OnPropertyChanged(); }}

        private string _BusinessOpeningTimes = "";
        public string BusinessOpeningTimes { get { return _BusinessOpeningTimes; } set { if (_BusinessOpeningTimes == value) return; _BusinessOpeningTimes = value; OnPropertyChanged(); }}

        private string _BusinessDOB = "";
        public string BusinessDOB { get { return _BusinessDOB; } set { if (_BusinessDOB == value) return; _BusinessDOB = value; OnPropertyChanged(); }}

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChanged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChanged(); } }

        #endregion

    }
}
