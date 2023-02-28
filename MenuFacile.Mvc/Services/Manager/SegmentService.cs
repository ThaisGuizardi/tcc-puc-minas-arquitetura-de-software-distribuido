using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Segment;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Manager
{
    public class SegmentService
    {
        private static HttpClient client = new HttpClient();

        public async Task<IEnumerable<GetActiveSegmentsDropdownViewModel>> GetActiveSegmentsDropdownAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Segment/v1/getactivesegmentsdropdownasync");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<GetActiveSegmentsDropdownViewModel>>(data);

                return model;
            }
            else
                return null; 
        }
    }
}
