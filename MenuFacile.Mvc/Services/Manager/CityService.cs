using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.City;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class CityService
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<GetCitiesByIdStateViewModel>> GetCitiesByIdStateAsync(int IdState)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/City/v1/getcitiesbyidstateasync?IdState={ IdState }");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<GetCitiesByIdStateViewModel>>(data);

                return model;
            }
            else
                return null;                
        }
    }
}
