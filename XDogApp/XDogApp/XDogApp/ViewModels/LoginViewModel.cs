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
    class LoginViewModel : BaseViewModel
    {
        public IDataStore<BaseId> DataStore = null;
        private LoginServices loginServices = new LoginServices();

        public ICommand ClickLogin { get; private set; }

        public LoginViewModel()
        {

            Email = Settings.Email;
            Password = Settings.Password;
            

            ClickLogin = new Command(async () =>
            {
                Tuple<bool, string> res = await GetLoginResponse(Email, Password);
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        #endregion


        public async Task<Tuple<bool, string>> GetLoginResponse(string email, string password)
        {
            Tuple<bool, string> res = null;

            LoginUser u = new LoginUser(email, password);

            if (u.IsValid())
            {

                bool bSuccess = await loginServices.LoginAsync(u.Email, u.Password);
                if (bSuccess)
                    res = new Tuple<bool, string>(true, "Login has been successful.");
                else
                    res = new Tuple<bool, string>(false, "Login failed. Incorrect email and/or password.");
            }
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
