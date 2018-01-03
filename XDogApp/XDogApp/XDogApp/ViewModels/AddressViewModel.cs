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
    class AddressViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }

        public AddressViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Address>>() ?? new MockDataStore<Address>();
            DataStore.InitializeAsync();

            
            ClickCreate = new Command(async () =>
            {
                Address item = new Address() { Address1 = this.Address1, Address2 = this.Address2, Address3 = this.Address3, Address4 = this.Address4,
                                               Town = this.Town, City = this.City, PostCode = this.PostCode, Country = this.Country};

                bool res = await DataStore.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successfully Saved" : "Failed to Save");

            });
        }


        #region Attributes
        private string _Address1 = "";
        public string Address1 { get { return _Address1; } set { if (_Address1 == value) return; _Address1 = value; OnPropertyChenged(); } }

        private string _Address2 = "";
        public string Address2 { get { return _Address2; } set { if (_Address2 == value) return; _Address2 = value; OnPropertyChenged(); } }

        private string _Address3 = "";
        public string Address3 { get { return _Address3; } set { if (_Address3 == value) return; _Address3 = value; OnPropertyChenged(); } }

        private string _Address4 = "";
        public string Address4 { get { return _Address4; } set { if (_Address4 == value) return; _Address4 = value; OnPropertyChenged(); } }

        private string _Town = "";
        public string Town { get { return _Town; } set { if (_Town == value) return; _Town = value; OnPropertyChenged(); } }

        private string _City = "";
        public string City { get { return _City; } set { if (_City == value) return; _City = value; OnPropertyChenged(); } }

        private string _PostCode = "";
        public string PostCode { get { return _PostCode; } set { if (_PostCode == value) return; _PostCode = value; OnPropertyChenged(); } }

        private string _Country = "";
        public string Country { get { return _Country; } set { if (_Country == value) return; _Country = value; OnPropertyChenged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChenged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChenged(); } }

        #endregion

    }
}
