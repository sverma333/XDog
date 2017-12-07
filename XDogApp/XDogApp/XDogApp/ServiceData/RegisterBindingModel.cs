using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.ServiceData
{
    public class OneStringBindingModel
    {
        public string Prm1 { get; set; }
    }

    public class RegisterBindingModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
