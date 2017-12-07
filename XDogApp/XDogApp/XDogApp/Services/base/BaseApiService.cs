using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Services
{
    public class BaseApiService
    {
        protected async Task<bool> CallServer(string serviceEnding, object data)
        {

            HttpClient client = new HttpClient();
            HttpContent context = new StringContent(JsonConvert.SerializeObject(data));
            context.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(PCL_AppConstants.sCurrentServiceURL + serviceEnding, context);

            return (response != null && response.IsSuccessStatusCode);
        }
    }
}
