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
    class MarketPlaceListViewModel : BaseListViewModel
    {
        public MarketPlaceListViewModel()
        {
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<MarketPlaceItem>>() ?? new MockDataStore<MarketPlaceItem>();
        }

        protected override List<ListDataItem> cleanData(IEnumerable<BaseId> data)
        {
            return (from w in data
                    select new ListDataItem()
                    {
                        Title1 = ((MarketPlaceItem)w).Description,
                        SubTitle1 = ((MarketPlaceItem)w).Currency + " " + ((MarketPlaceItem)w).Price.ToString(),
                        SubTitle2 =((MarketPlaceItem)w).Price.ToString(),
                        Image1 = ((MarketPlaceItem)w).Price.ToString(), // TODO change to image uri
                    }).ToList();
        }

        
    }
}
