using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDogApp.Models;
using XDogApp.Utils;
using XDogApp.ViewModels;

namespace XDogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusinessPage : ContentPage
    {
        public BusinessPage()
        {
            InitializeComponent();
            //Label_Response.Text = AppResources.AppResources.RegisterResponseDef;

        }
    }
}