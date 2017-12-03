using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace XDogApp.Services
{
    public class MobileServiceSQLiteStoreWithLogging : MobileServiceSQLiteStore
    {
        private bool logResults;
        private bool logParameters;

        public MobileServiceSQLiteStoreWithLogging(string fileName, bool logResults) : base(fileName)
        {
            this.logResults = logResults;
            this.logParameters = logResults;
        }

        protected override IList<JObject> ExecuteQueryInternal(string tableName, string sql, IDictionary<string, object> parameters)
        {
            Debug.WriteLine(sql);

            if (logParameters)
                PrintDictionary(parameters);

            var result = base.ExecuteQueryInternal(tableName, sql, parameters);

            if (logResults && result != null)
            {
                foreach (var token in result)
                    Debug.WriteLine(token);
            }

            return result;
        }

        protected override void ExecuteNonQueryInternal(string sql, IDictionary<string, object> parameters)
        {
            Debug.WriteLine(sql);

            if (logParameters)
                PrintDictionary(parameters);

            base.ExecuteNonQueryInternal(sql, parameters);
        }

        private void PrintDictionary(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
                return;

            foreach (var pair in dictionary)
                Debug.WriteLine("{0}:{1}", pair.Key, pair.Value);
        }
    }

    //public class LoggingHandler : DelegatingHandler
    //{
    //    private bool logRequestResponseBody;

    //    public LoggingHandler(bool logRequestResponseBody = false)
    //    {
    //        this.logRequestResponseBody = logRequestResponseBody;
    //    }

    //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    //    {
    //        Console.WriteLine("Request: {0} {1}", request.Method, request.RequestUri.ToString());

    //        if (logRequestResponseBody && request.Content != null)
    //        {
    //            var requestContent = await request.Content.ReadAsStringAsync();
    //            Console.WriteLine(requestContent);
    //        }

    //        var response = await base.SendAsync(request, cancellationToken);

    //        Console.WriteLine("Response: {0}", response.StatusCode);

    //        if (logRequestResponseBody)
    //        {
    //            var responseContent = await response.Content.ReadAsStringAsync();
    //            Console.WriteLine(responseContent);
    //        }

    //        return response;
    //    }
    //}
}
