using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDogApp.Helpers;
using XDogApp.Views;

namespace XDogApp.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDMainPageMaster : ContentPage
    {
        public ListView ListView;

        public MDMainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDMainPageMasterViewModel();
            ListView = MenuListView;
        }

        class MDMainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuItem> MenuItems { get; set; }

            public MDMainPageMasterViewModel()
            {
                // Build the Menu
                List<MenuItem> lstMenu = buildMenu();
                MenuItems = new ObservableCollection<MenuItem>(lstMenu);
            }

            private List<MenuItem> buildMenu()
            {
                string tab = "           ";
                List<MenuItem> lstMenu = new List<MenuItem>()
                {
                    new MenuItem() { Title = tab + "Edit Profile", Icon = "menu_stock.png", TargetType = typeof(DogOwnerPage) },
                    new MenuItem() { Title = "Find Near By"},
                    new MenuItem() { Title = tab + "Dog Walks", Icon = "menu_stock.png", TargetType = typeof(DogWalkListPage) },
                    new MenuItem() { Title = tab + "Dog Owners", Icon = "menu_stock.png", TargetType = typeof(DogOwnerListPage) },
                    new MenuItem() { Title = tab + "Dogs", Icon = "menu_stock.png", TargetType = typeof(DogListPage) },
                    new MenuItem() { Title = "Services Near By"},
                    new MenuItem() { Title = tab + "Veterinary Clinics", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Pet Shops", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Walkers", Icon = "menu_stock.png", TargetType = typeof(PrivateBusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Sitters", Icon = "menu_stock.png", TargetType = typeof(PrivateBusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Sleepovers", Icon = "menu_stock.png", TargetType = typeof(PrivateBusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Groomers", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Photograhers", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Dog Trainers", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Kennels", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = tab + "Rescue Centres", Icon = "menu_stock.png", TargetType = typeof(BusinessListPage) },
                    new MenuItem() { Title = "Market Place"},
                    new MenuItem() { Title = tab + "Free Things", Icon = "menu_stock.png", TargetType = typeof(MarketPlaceListPage) },
                    new MenuItem() { Title = tab + "Lost/Found", Icon = "menu_stock.png", TargetType = typeof(MarketPlaceListPage) },
                    new MenuItem() { Title = tab + "Buy/Sell", Icon = "menu_stock.png", TargetType = typeof(MarketPlaceListPage) },
                };

                bool bLoggedIn = !string.IsNullOrEmpty(Settings.Token);

                lstMenu.Add(new MenuItem() { Title = "Account"});
                if (!bLoggedIn) lstMenu.Add(new MenuItem() { Title = tab + "Login", Icon = "menu_inbox.png", TargetType = typeof(LoginPage) });
                if(!bLoggedIn) lstMenu.Add(new MenuItem() { Title = tab + "Register", Icon = "menu_inbox.png", TargetType = typeof(RegisterPage) });
                if (bLoggedIn) lstMenu.Add(new MenuItem() { Title = tab + "Log Out", Icon = "menu_inbox.png", TargetType = typeof(LoginPage) });  //TODO Logout

                return lstMenu;
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}