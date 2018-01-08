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
    public class ListDataItem
    {
         public string Image1 { get; set; }
         public string Title1 { get; set; }
         public string SubTitle1 { get; set; }
         public string SubTitle2 { get; set; }
    }

    class DogListViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand RefreshDataCommand { get; private set; }

        private bool _isRefreshing = false;
        public bool IsRefreshing { get { return _isRefreshing; } set { _isRefreshing = value; OnPropertyChanged();}}

        public DogListViewModel()
        {
            //SV initialise backend framework

            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Dog>>() ?? new MockDataStore<Dog>();
            RefreshDataCommand = new Command(async () =>
            {
                try
                {
                    IsRefreshing = true;
                    await DataStore.InitializeAsync();
                    var data = await DataStore.GetItemsAsync(true);
                    obvDataList = new ObservableCollection<ListDataItem>(cleanData(data));
                }
                finally
                {
                    IsRefreshing = false;
                }
            });
        }

        private static List<ListDataItem> cleanData(IEnumerable<BaseId> data)
        {
            return (from w in data
                select new ListDataItem()
                {
                    Title1    = ((TodoItem)w).Text,
                    SubTitle1 = ((TodoItem)w).Text,
                    SubTitle2 = ((TodoItem)w).Text,
                    Image1 = ((TodoItem)w).Text // TODO change to image uri
                }).ToList();

            //return (from w in data
            //    select new ListDataItem()
            //    {
            //        Title1    = ((Dog)w).Name,
            //        SubTitle1 = ((Dog)w).Breed,
            //        SubTitle2 = ((Dog)w).Gender,
            //        Image1 = ((Dog)w).Gender // TODO change to image uri
            //    }).ToList();
        }


        #region Attributes
        public ObservableCollection<ListDataItem> obvDataList { get; set; }
        #endregion

    }
}
