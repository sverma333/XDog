using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Services
{
    public class BaseApiService
    {
        protected async Task<bool> callServer(string serviceEnding, object data)
        {

            HttpClient client = new HttpClient();
            HttpContent context = new StringContent(JsonConvert.SerializeObject(data));

            HttpResponseMessage response = await client.PostAsync(PCL_AppConstants.sCurrentServiceURL + serviceEnding, context);

            return (response != null && response.IsSuccessStatusCode);
        }
    }
}
