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
using ClientServerData.DataObjects;

namespace XDogApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        //public IDataStore<BaseId> DataStore = null;

        //public ICommand ClickTest1 { get; private set; }
        //public ICommand ClickTest2 { get; private set; }

        public ICommand ClickVerification { get; private set; }
        public ICommand ClickRegister { get; private set; }
        private LoginServices loginServices = new LoginServices();

        public RegisterViewModel()
        {
            //SV initialise backend framework
            //DataStore = (IDataStore<BaseId>)DependencyService.Get<AzureDataStore<TodoItem>>() ?? new MockDataStore<TodoItem>();
            //DataStore.InitializeAsync();

//            ClickTest1 = new Command(async () =>
//            {
//                TodoItem item = new TodoItem { Text = "Awesome item " + DateTime.Now.ToString("yyyy-MM-dd HH:mmm:ss") };
//                await DataStore.AddItemAsync(item);
//            });

//            ClickTest2 = new Command(async () =>
//            {
//                var lst = (await DataStore.GetItemsAsync(true)).ToList();
////                int itemsCount = (await DataStore.GetItemsAsync(true)).ToList().Count;
//                int itemsCount = lst.Count;
//                System.Diagnostics.Debug.WriteLine($"Rows in table {itemsCount}");
//            });

            ClickVerification = new Command(async () =>
            {
                Tuple<bool, string> res = await GetVerificationResponse(Email);
                ResponseType = (res.Item1 ? 1 : 2);
                ResponseText = res.Item2;
            }) ;

            ClickRegister = new Command(async () =>
            {
                Tuple<bool, string> res = await GetRegResponse(Email, VerficationCode, Password, ConfirmPassword);
                ResponseType = (res.Item1 ? 1 : 2);
                ResponseText = res.Item2;
            });
        }


        #region Attributes

        private string _Email = "";
        public string Email { get { return _Email; } set { if (_Email == value) return; _Email = value;  OnPropertyChenged(); }}

        private string _VerficationCode = "";
        public string VerficationCode { get { return _VerficationCode; } set { if (_VerficationCode == value) return; _VerficationCode = value; OnPropertyChenged(); } }

        private string _Password = "";
        public string Password { get { return _Password; } set { if (_Password == value) return; _Password = value; OnPropertyChenged(); } }

        private string _ConfirmPassword = "";
        public string ConfirmPassword { get { return _ConfirmPassword; } set { if (_ConfirmPassword == value) return; _ConfirmPassword = value; OnPropertyChenged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChenged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChenged(); } }

        #endregion


        public async Task<Tuple<bool, string>> GetRegResponse(string email, string verificationCode, string password, string confirmPassword)
        {
            Tuple<bool, string> res = null;

            RegisterUser u = new RegisterUser(email, verificationCode, password, confirmPassword);

            if (u.IsValid())
            {
                bool isSuccess = await loginServices.RegisterAsync(u.Email, u.VerificationCode, u.Password, u.ConfirmPassword);
                if (isSuccess)
                    res = new Tuple<bool, string>(true, "Registration has been successful.");
                else
                    res = new Tuple<bool, string>(false, "Registration failed at the server");
            }
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(false, "Registration failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(false, "Registration failed. Please enter a valid email address.");
                else if (u.PasswordMisMatch())
                    res = new Tuple<bool, string>(false, "Registration failed. Passwords do not match.");
            }

            return res;
        }

        public async Task<Tuple<bool, string>> GetVerificationResponse(string email)
        {
            Tuple<bool, string> res = null;

            VertifyUser u = new VertifyUser(email);

            if (u.IsValid())
            {
                bool isSuccess = await loginServices.VerifyAsync(u.Email);
                if (isSuccess)
                    res = new Tuple<bool, string>(true, $"Sending Verification Code to {email}");
                else
                    res = new Tuple<bool, string>(false, $"Verification email failed and has not been sent to {email}");
            }
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(false, "Registration failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(false, "Registration failed. Please enter a valid email address.");
            }

            return res;
        }
    }
}
