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
using ClientServerData.DataObjects;

namespace XDogApp.ViewModels
{
    class DogViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }

        public DogViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<AzureDataStore<Dog>>() ?? new MockDataStore<Dog>();
            DataStore.InitializeAsync();

            
            ClickCreate = new Command(async () =>
            {
                Dog item = new Dog { Name = this.Name, Interests = new List<string>(new string[] { this.Interests }), Bio = this.Bio, DOB = Convert.ToDateTime(this.DOB) };                
                await DataStore.AddItemAsync(item);
            });
        }


        #region Attributes
        private string _Name = "";
        public string Name { get { return _Name; } set { if (_Name == value) return; _Name = value; OnPropertyChenged(); }}

        private string _Interests = "";
        public string Interests { get { return _Interests; } set { if (_Interests == value) return; _Interests = value; OnPropertyChenged(); } }

        private string _Bio = "";
        public string Bio { get { return _Bio; } set { if (_Bio == value) return; _Bio = value; OnPropertyChenged(); } }


        private string _DOB = "";
        public string DOB { get { return _DOB; } set { if (_DOB == value) return; _DOB = value; OnPropertyChenged(); } }

        #endregion

    }
}
