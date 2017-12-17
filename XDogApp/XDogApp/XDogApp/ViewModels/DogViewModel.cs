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
    class DogViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }

        public DogViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Dog>>() ?? new MockDataStore<Dog>();
            DataStore.InitializeAsync();

            
            ClickCreate = new Command(async () =>
            {
//                Dog item = new Dog { Name = this.Name, Interests = new List<string>(new string[] { this.Interests }), Bio = this.Bio, DOB = Convert.ToDateTime(this.DOB) };
                Dog item = new Dog { Name = this.Name };

                //prep in calling page.
                //item.MainOwnerId = this.MainOwnerId; item.MainOwnerUserId = this.MainOwnerId;

                bool res = await DataStore.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successfully Saved" : "Failed to Save");

            });
        }


        #region Attributes
        private string _MainOwnerId = "";
        public string MainOwnerId { get { return _MainOwnerId; } set { if (_MainOwnerId == value) return; _MainOwnerId = value; OnPropertyChenged(); } }

        private string _MainOwnerUserId = "";
        public string MainOwnerUserId { get { return _MainOwnerUserId; } set { if (_MainOwnerUserId == value) return; _MainOwnerUserId = value; OnPropertyChenged(); } }

        private string _Name = "";
        public string Name { get { return _Name; } set { if (_Name == value) return; _Name = value; OnPropertyChenged(); }}

        private string _Interests = "";
        public string Interests { get { return _Interests; } set { if (_Interests == value) return; _Interests = value; OnPropertyChenged(); } }

        private string _Bio = "";
        public string Bio { get { return _Bio; } set { if (_Bio == value) return; _Bio = value; OnPropertyChenged(); } }


        private string _DOB = "";
        public string DOB { get { return _DOB; } set { if (_DOB == value) return; _DOB = value; OnPropertyChenged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChenged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChenged(); } }

        #endregion

    }
}
