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
using System.Diagnostics;

namespace XDogApp.ViewModels
{
    public class BaseListViewModel : BaseViewModel
    {
        protected IDataStore<BaseId> DataStore = null;

        public ICommand RefreshDataCommand { get; private set; }

        private bool _isRefreshing = false;
        public bool IsRefreshing { get { return _isRefreshing; } set { _isRefreshing = value; OnPropertyChanged();}}

        public BaseListViewModel()
        {
            RefreshDataCommand = new Command(async () =>
            {
                try
                {
                    IsRefreshing = true;
                    await DataStore.InitializeAsync();
                    var data = await DataStore.GetItemsAsync(true);
                    Debug.WriteLine("Debugger: " + data.Count());
                    obvDataList = new ObservableCollection<ListDataItem>(cleanData(data));
                }
                finally
                {
                    IsRefreshing = false;
                }

            });
        }

        protected virtual List<ListDataItem> cleanData(IEnumerable<BaseId> data)
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


        public ObservableCollection<ListDataItem> obvDataList { get; set; }

    }
}
