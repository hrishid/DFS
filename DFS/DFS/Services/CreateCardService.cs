using DFS.Core;
using DFS.Models;
using DFS.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DFS.Services
{
    public interface ICreateCardService
    {
        Task<List<LocationModel>> GetLocations();
    }
    public interface IGetDynamicFlow
    {
        Task<List<DynamicFlow>> GetDynamicFlow(int locationId);
    }
    public interface IGetDepartments
    {
        Task<List<DepartmentModel>> GetDepartments(int locationId, int dynamicFlowId);
    }

    public interface IGetBucketList
    {
        Task<List<BucketModel>> GetBucketList();
    }
     public interface IGetProcessSteps
    {
        Task<List<ProcessStepModel>> GetProcessStep(int locationId,int dynamicFlowId,int departmentId);
    }

    public interface IPostCardService
    {
        Task<bool> PostCard(CICardModel card);
    }



    public class CreateCardService :BaseAPI, ICreateCardService, IGetDynamicFlow,IGetDepartments,IGetBucketList, IGetProcessSteps, IPostCardService
    {
        public async Task<bool>PostCard(CICardModel card)
        {
            using (var client = CreateClient("CiDashBoard/buckets?ClientID=" + App.User.clientId))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(card));

                HttpResponseMessage response = await client.PostAsync(client.BaseAddress,).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
        }

        public async Task<List<BucketModel>> GetBucketList()
        {
            using (var client = CreateClient("CiDashBoard/buckets?ClientID=" + App.User.clientId))
            {
              
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<BucketModel>>(await response.Content.ReadAsStringAsync());
                }

                return null;

            }
        }

       

        public async Task<List<DepartmentModel>> GetDepartments(int locationId, int dynamicFlowId)
        {
            using (var client = CreateClient(string.Format("CiDashBoard/departments?dynamicFlowId={0}?locationId={1}", dynamicFlowId,locationId)))
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DepartmentModel>>(await response.Content.ReadAsStringAsync());
                }

                return null;
            }
        }
        public async Task<List<DynamicFlow>> GetDynamicFlow(int locationId)
        {
            using (var client = CreateClient("CiDashBoard/dynamicflows?locationId=" + locationId))
            {
                //client.DefaultRequestHeaders.Add("token", App.User.token);
                //client.DefaultRequestHeaders.Add("ClientId", App.User.clientId  );
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DynamicFlow>>(await response.Content.ReadAsStringAsync());
                }

                return null;

            }
        }

        public async Task<List<LocationModel>> GetLocations()
        {
            using (var client = CreateClient("CiDashBoard/locations?ClientID="+App.User.clientId))
            {
                //client.DefaultRequestHeaders.Add("token", App.User.token);
                //client.DefaultRequestHeaders.Add("ClientId", App.User.clientId  );
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<LocationModel>>(await response.Content.ReadAsStringAsync());
                }

                return null;

            }
        }

        public async Task<List<ProcessStepModel>> GetProcessStep(int locationId, int dynamicFlowId, int departmentId)
        {
            using (var client = CreateClient(string.Format("CiDashBoard/processsteps?locationId={0}?dynamicFlowId={1}?departmentId={2}", locationId, dynamicFlowId,departmentId)))
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProcessStepModel>>(await response.Content.ReadAsStringAsync());
                }

                return null;
            }
        }
    }
}
