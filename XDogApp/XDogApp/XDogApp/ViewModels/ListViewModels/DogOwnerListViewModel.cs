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
    class DogOwnerListViewModel : BaseListViewModel
    {
        public DogOwnerListViewModel()
        {
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<DogOwner>>() ?? new MockDataStore<DogOwner>();
        }

        protected override List<ListDataItem> cleanData(IEnumerable<BaseId> data)
        {
            return (from w in data
                    select new ListDataItem()
                    {
                        Title1 = ((DogOwner)w).FirstName + " " + ((DogOwner)w).Surname,
                        SubTitle1 = ((DogOwner)w).Gender,
                        SubTitle2 = ((DogOwner)w).AgeRangeMin.ToString(),  // TODO change to Dog Names
                        Image1 = ((DogOwner)w).Gender                      // TODO change to image uri
                    }).ToList();
        }

        
    }
}
