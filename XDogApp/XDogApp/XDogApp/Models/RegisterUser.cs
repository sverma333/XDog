using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Utils;

namespace XDogApp.Models
{
    public class RegisterUser
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string VerificationCode { get; set; }

        public RegisterUser() { }
        public RegisterUser(string email, string verificationCode, string password, string confirmPassword)
        {
            Email = email;
            VerificationCode = verificationCode;
            Password = password;
            ConfirmPassword = confirmPassword;
        }


        public bool IsValid()
        {
            bool bRet = true;
            if (HasBlanks() || PasswordMisMatch() || InValidEmail())
                bRet = false;

            return bRet;
        }

        public bool HasBlanks()
        {
            return StringUtils.HasBlanks(Email, VerificationCode, Password, ConfirmPassword);
        }

        public bool PasswordMisMatch()
        {
            return Password != ConfirmPassword;
        }

        public bool InValidEmail()
        {
            return !StringUtils.IsValidEmail(Email);
        }
    }
}
