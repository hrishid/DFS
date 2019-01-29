using DFS.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DFS.Services
{
    public interface ILoginService
    {
        Task<UserModel> GetUser(string userName, string password);
    }

    public class LoginService : BaseAPI, ILoginService
    {
        public async Task<UserModel> GetUser(string userName, string pass)
        {
            using (var client = CreateCLientForLogin("account"))
            {
                client.DefaultRequestHeaders.Add("Username", userName);
                client.DefaultRequestHeaders.Add("Password", pass);              
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
                }

                return null;

            }
        }
    }
}
