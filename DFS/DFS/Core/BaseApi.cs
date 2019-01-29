using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DFS.Core
{
    public abstract class BaseAPI
    {
        private string baseURI = "http://dfsportal.ideedsms.info/" +
            "/api/"; //52.237.72.250:9000

        public HttpClient CreateClient(string controller)
        {
            var client = new HttpClient();
            //9000
            //client.DefaultRequestHeaders.Add("Authorization", App.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(App.User.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(new Uri(baseURI), controller);
            return client;
        }
        public HttpClient CreateCLientForLogin(string controller)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(new Uri(baseURI), controller);
            return client;
        }
    }
}
