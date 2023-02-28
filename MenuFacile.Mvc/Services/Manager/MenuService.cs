using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Menu;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class MenuService
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<MenuListViewModel>> MenuListAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Menu/v1/Menulistasync");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<IEnumerable<MenuListViewModel>>(data);

                return model;
            }
            else 
                return null;
        }
    }
}
