using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Restaurant;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class RestaurantService
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<RestaurantListViewModel>> RestaurantListAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Restaurant/v1/restaurantlistasync");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<IEnumerable<RestaurantListViewModel>>(data);

                return model;
            }
            else
                return null;                
        }
    }
}
