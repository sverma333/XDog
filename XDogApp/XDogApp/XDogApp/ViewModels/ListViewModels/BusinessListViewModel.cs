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
    class BusinessListViewModel : BaseListViewModel
    {
        public BusinessListViewModel()
        {
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Business>>() ?? new MockDataStore<Business>();
        }

        protected override List<ListDataItem> cleanData(IEnumerable<BaseId> data)
        {
            return (from w in data
                    select new ListDataItem()
                    {
                        Title1 = ((Business)w).Name,
                        SubTitle1 = ((Business)w).Type,
                        SubTitle2 = ((Business)w).OpeningTimes,
                        Image1 = ((Business)w).OpeningTimes // TODO change to image uri
                    }).ToList();
        }

        
    }
}
