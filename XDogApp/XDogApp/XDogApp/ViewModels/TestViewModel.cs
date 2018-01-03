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
    class TestViewModel : BaseViewModel
    {
        public IDataStore<BaseId> DataStore = null;
        private AzureDataStore<TodoItem> testServices = new AzureDataStore<TodoItem>();

        private string _EntryText = "";
        public string EntryText { get { return _EntryText; } set { if (_EntryText == value) return; _EntryText = value; OnPropertyChenged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChenged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChenged(); } }


        public ICommand ClickTest { get; private set; }

        public TestViewModel()
        {
            ClickTest = new Command(async () =>
            {
                TodoItem item = new TodoItem() { Text = EntryText };
                bool res = await testServices.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successful inserted" : "Failed to insert");
            });
        }





    }
}
