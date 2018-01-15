using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XDogApp.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDMainPage : MasterDetailPage
    {
        public MDMainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += MainMenuItem_Selected;
            MasterBehavior = MasterBehavior.Popover;

        }

        private void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuItem;
            if (item == null)
                return;

            NavigationPage curPage = Detail as NavigationPage;
            if (curPage as NavigationPage == null)
                return;

            if (curPage.CurrentPage.GetType() != item.TargetType)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title.Trim();

                Detail = new NavigationPage(page);
            }
            
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}