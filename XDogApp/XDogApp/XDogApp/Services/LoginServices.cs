using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XDogApp.ServiceData;

namespace XDogApp.Services
{
    public class LoginServices : BaseApiService
    {
        public async Task<bool> RegisterAsync(string email, string verificationCode, string password, string confirmpassword)
        {
            return await CallServer("/api/Account/Register", new RegisterBindingModel() { Email = email, Password = password, ConfirmPassword = confirmpassword });
        }

        public async Task<bool> VerifyAsync(string email)
        {
            return await CallServer($"/api/Account/Verify", new FiveStringIntDblBindingModel() { sPrm1 = email});
        }
    }
}
