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

        private void setResponseLabel(bool isWarning, string m)
        {
            Label_Response.Text = m;

            if (isWarning)
            {
                Label_Response.BackgroundColor = Color.Red;
                Label_Response.TextColor = Color.White;
            }
            else
            {
                Label_Response.BackgroundColor = Color.White;
                Label_Response.TextColor = Color.Black;
            }
        }

        private void btnSendVerification_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Entry_Email.Text))
                setResponseLabel(true, "Login Failed. Login information incomplete.");
            else
                if (StringUtils.IsValidEmail(Entry_Email.Text))
                    setResponseLabel(false, $"Sending Verification Code to {Entry_Email.Text}");
                else
                    setResponseLabel(true, "Login Failed. Please enter a valid email address.");
        }



        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            User u = new User(Entry_Email.Text, Entry_Password.Text);

            if (!StringUtils.HasBlanks(Entry_Email.Text, Entry_VerificationCode.Text, Entry_Password.Text))
                if (Entry_Password.Text != Entry_ConfirmPassword.Text)
                    setResponseLabel(true, "Login Failed. Passwords do not match.");
                else
                    setResponseLabel(false, "Login Success");
            else
                setResponseLabel(true, "Login Failed. Login information incomplete.");


        }
    }
}