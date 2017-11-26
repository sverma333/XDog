using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Utils;

namespace XDogApp.Models
{
    public class VertifyUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public VertifyUser() { }
        public VertifyUser(string email)
        {
            Email = email;
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
            return StringUtils.HasBlanks(Email);
        }


        public bool InValidEmail()
        {
            return !StringUtils.IsValidEmail(Email);
        }
    }
}
