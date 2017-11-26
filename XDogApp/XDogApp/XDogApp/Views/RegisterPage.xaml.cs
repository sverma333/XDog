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
    public partial class RegisterPage : ContentPage
    {
        private RegisterViewModel vm = new RegisterViewModel();
        public RegisterPage()
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
            Tuple<bool, string> res = vm.GetVerificationRegResponse(Entry_Email.Text);
            setResponseLabel(res.Item1, res.Item2);
        }



        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Tuple<bool, string> res = vm.GetRegResponse(Entry_Email.Text, Entry_VerificationCode.Text, Entry_Password.Text, Entry_ConfirmPassword.Text);
            setResponseLabel(res.Item1, res.Item2); 
        }
    }
}