using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Category;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class CategoryServices
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<CategoryListViewModel>> CategoryListAsync()
        {
            IEnumerable<CategoryListViewModel> model;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Category/v1/Categorylistasync");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                return model = JsonConvert.DeserializeObject<IEnumerable<CategoryListViewModel>>(data);
            }
            else
                return null;
        }
    }
}
