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
using Plugin.Media;
using Plugin.Media.Abstractions;
using XDogApp.Utils;
using Plugin.MediaManager;
using PCLStorage;
using System.IO;
using System.Collections.ObjectModel;

namespace XDogApp.ViewModels
{
    class DogListViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public DogListViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<DogOwner>>() ?? new MockDataStore<DogOwner>();
            DataStore.InitializeAsync();
            Initialize();
        }

        public async void Initialize()
        {
            var data = await DataStore.GetItemsAsync(true);
            List<DogOwner> lst = new List<DogOwner>();
            foreach (BaseId d in data)
                System.Diagnostics.Debug.WriteLine(d.Id);

            obvDataList = new ObservableCollection<DogOwner>(lst);
        }

        #region Attributes
        public ObservableCollection<DogOwner> obvDataList { get; set; }
        #endregion

    }
}
