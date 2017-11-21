using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Utils;

namespace XDogApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }
        public User (string email, string password)
        {
            Email = email;
            Password = password;
        }


        public bool IsValid()
        {
            return !StringUtils.HasBlanks(Email, Password);
        }
    }
}
