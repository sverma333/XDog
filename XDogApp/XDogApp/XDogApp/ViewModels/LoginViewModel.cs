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

namespace XDogApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public IDataStore<BaseAzureData> DataStore = null;

        public ICommand ClickLogin { get; private set; }

        public LoginViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseAzureData>)DependencyService.Get<AzureDataStore<TodoItem>>() ?? new MockDataStore<TodoItem>();
            DataStore.InitializeAsync();

            ClickLogin = new Command(() =>
            {
                Tuple<bool, string> res = GetLoginResponse(Email, Password);
                ResponseType = (res.Item1 ? 1 : 2);
                ResponseText = res.Item2;
            });
        }


        #region Attributes
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email == value) return;
                _Email = value; 
                OnPropertyChenged();
            }
        }


        private string _VerficationCode = "";
        public string VerficationCode
        {
            get { return _VerficationCode; }
            set
            {
                if (_VerficationCode == value) return;
                _VerficationCode = value;
                OnPropertyChenged();
            }
        }

        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value) return;
                _Password = value;
                OnPropertyChenged();
            }
        }

        private string _ConfirmPassword = "";
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                if (_ConfirmPassword == value) return;
                _ConfirmPassword = value;
                OnPropertyChenged();
            }
        }

        private string _ResponseText = "";
        public string ResponseText
        {
            get { return _ResponseText; }
            set
            {
                if (_ResponseText == value) return;
                _ResponseText = value;
                OnPropertyChenged();
            }
        }

        private int _ResponseType = 1;
        public int ResponseType
        {
            get { return _ResponseType; }
            set
            {
                if (_ResponseType == value) return;
                _ResponseType = value;
                OnPropertyChenged();
            }
        }

        #endregion


        public Tuple<bool, string> GetLoginResponse(string email, string password)
        {
            Tuple<bool, string> res = null;

            LoginUser u = new LoginUser(email, password);

            if (u.IsValid())
                res = new Tuple<bool, string>(true, "Login has been successful.");
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(false, "Login failed. Login information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(false, "Login failed. Please enter a valid email address.");
            }

            return res;
        }
    }
}
