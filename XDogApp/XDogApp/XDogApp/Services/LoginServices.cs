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
    public class LoginServices
    {

        public async Task<bool> RegisterAsync(string email, string verificationCode, string password, string confirmpassword)
        {
            string serviceEnding = "/api/Account";
            RegisterBindingModel d = new RegisterBindingModel() { Email = email, Password = password, ConfirmPassword = confirmpassword };

            HttpClient client = new HttpClient();
            HttpContent context = new StringContent(JsonConvert.SerializeObject(d));

            var response = await client.PostAsync(PCL_AppConstants.sCurrentServiceURL + serviceEnding, context);

            return response.IsSuccessStatusCode;
        }
    }
}
