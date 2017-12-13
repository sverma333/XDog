using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Helpers;
using XDogApp.ServiceData;

namespace XDogApp.Services
{
    public class LoginServices : BaseApiService
    {
        public async Task<bool> RegisterAsync(string email, string verificationCode, string password, string confirmpassword)
        {
            var ret = await CallServer("/api/Account/Register", new RegisterBindingModel() { Email = email, Password = password, ConfirmPassword = confirmpassword });
            if (ret)
            {
                Settings.Email = email;
                Settings.Password = password;
            }
            else
            {
                Settings.Email = "";
                Settings.Password = "";
            }
            return ret;
        }

        public async Task<bool> VerifyAsync(string email)
        {
            return await CallServer($"/api/Account/Verify", new FiveStringIntDblBindingModel() { sPrm1 = email});
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("username", email));
            lst.Add(new KeyValuePair<string, string>("password", password));
            lst.Add(new KeyValuePair<string, string>("grant_type", "password"));

            var request = new HttpRequestMessage(HttpMethod.Post, PCL_AppConstants.sCurrentServiceURL + "/Token") { Content = new FormUrlEncodedContent(lst) };

            var response = await new HttpClient().SendAsync(request);
            bool bGood = (response != null && response.IsSuccessStatusCode);
            string jwt = await response.Content.ReadAsStringAsync();

            if (bGood)
            { 
                JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
                var accessToken = jwtDynamic.Value<string>("access_token");
                Settings.Token = accessToken;
            }

            Debug.WriteLine(jwt);
            return bGood;
            //return await CallServer($"/api/Account/Login", new FiveStringIntDblBindingModel() { sPrm1 = email, sPrm2 = password });
        }
    }
}
