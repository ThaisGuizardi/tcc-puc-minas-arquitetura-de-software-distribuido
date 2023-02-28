using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.State;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class StateService
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<GetStatesViewModel>> GetStatesAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/State/v1/getstatesasync");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<GetStatesViewModel>>(data);

                return model;
            }
            else
                return null; ;
        }
    }
}
