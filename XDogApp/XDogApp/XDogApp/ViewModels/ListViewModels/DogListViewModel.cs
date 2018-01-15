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
    public class DogListViewModel : BaseListViewModel
    {
        public DogListViewModel()
        {
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Dog>>() ?? new MockDataStore<Dog>();
        }

        protected override List<ListDataItem> cleanData(IEnumerable<BaseId> data)
        {
            return (from w in data
                    select new ListDataItem()
                    {
                        Title1 = ((Dog)w).Name,
                        SubTitle1 = ((Dog)w).Breed,
                        SubTitle2 = ((Dog)w).Gender,
                        Image1 = ((Dog)w).Gender // TODO change to image uri
                    }).ToList();
        }
    }
}
