using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XDogApp.Models;
using XDogApp.Utils;

namespace XDogApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnSendverification_Clicked(object sender, EventArgs e)
        {
            User u = new User(Entry_Email.Text, Entry_Password.Text);
            if (u.IsValid())
                DisplayAlert("Login", $"Sending Verification Code to {Entry_Email.Text}", "Ok");
            else
                DisplayAlert("Login", "Login Information is not correct", "Ok");

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            User u = new User(Entry_Email.Text, Entry_Password.Text);

            if (u.IsValid() && StringUtils.AreAllNullOrWhiteSpace(Entry_VerificationCode.Text))
                DisplayAlert("Login", "Login Success", "Ok");
            else
                DisplayAlert("Login", "Login Information is not correct", "Ok");

        }
    }
}