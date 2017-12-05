using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Utils;

namespace XDogApp.Models
{
    public class LoginUser
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUser() { }
        public LoginUser(string email, string password)
        {
            Email = email;
            Password = password;
        }


        public bool IsValid()
        {
            bool bRet = true;
            if (HasBlanks() || InValidEmail())
                bRet = false;

            return bRet;
        }

        public bool HasBlanks()
        {
            return StringUtils.HasBlanks(Email, Password);
        }


        public bool InValidEmail()
        {
            return !StringUtils.IsValidEmail(Email);
        }
    }
}
