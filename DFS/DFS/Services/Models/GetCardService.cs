using DFS.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DFS.Services.Models
{
    public interface IGetCards
    {
        Task<List<CardModel>> GetAllUserCards();
    }

    public class GetCardService : BaseAPI, IGetCards
    {
        public async Task<List<CardModel>> GetAllUserCards()
        {
            using (var client = CreateClient(string.Format("CiDashBoard/getusercards?UserId={0}&type={1}", App.User.id, 0))) 
            {

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                   return JsonConvert.DeserializeObject<List<CardModel>>(await response.Content.ReadAsStringAsync());
                }

                return null;

            }
        }
    }
}
