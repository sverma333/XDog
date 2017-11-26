using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Models;

namespace XDogApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {

        public RegisterViewModel() { }

        public Tuple<bool, string> GetRegResponse(string email, string verificationCode, string password, string confirmPassword)
        {
            Tuple<bool, string> res = null;

            RegisterUser u = new RegisterUser(email, verificationCode, password, confirmPassword);

            if (u.IsValid())
                res = new Tuple<bool, string>(false, "Registration has been successful.");
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(true, "Registration Failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(true, "Registration Failed. Please enter a valid email address.");
                else if (u.PasswordMisMatch())
                    res = new Tuple<bool, string>(true, "Registration Failed. Passwords do not match.");
            }

            return res;
        }

        public Tuple<bool, string> GetVerificationRegResponse(string email)
        {
            Tuple<bool, string> res = null;

            VertifyUser u = new VertifyUser(email);

            if (u.IsValid())
                res = new Tuple<bool, string>(false, $"Sending Verification Code to {email}");
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(true, "Registration Failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(true, "Registration Failed. Please enter a valid email address.");
            }

            return res;
        }
    }
}
