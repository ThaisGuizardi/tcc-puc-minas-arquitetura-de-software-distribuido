using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Order.Dashboard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.Order
{
    public class OrderService
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<GetPaymentMethodsByIdRestaurantViewModel>> GetPaymentMethodsByIdRestaurantAsync(int idRestaurant)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:44378/api/Order/v1/GetPaymentMethodsByIdRestaurantAsync?IdRestaurant={ idRestaurant }");

            string data = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IEnumerable<GetPaymentMethodsByIdRestaurantViewModel>>(data);

            return model;
        }

        public async Task<int> AddOrderAsync(OrderViewModel model)
        {
            OrderAddViewModel orderAdd = new OrderAddViewModel();
            int idOrder = 0;

            if (model.OrderAdd.Status == "PreOrder")
            {
                orderAdd.Active = true;
                orderAdd.EditDateTime = DateTime.Now;
                orderAdd.Status = model.OrderAdd.Status;
                orderAdd.CreateDateTime = DateTime.Now;
                orderAdd.LinkOrder = model.OrderAdd.LinkOrder;
                orderAdd.IdPaymentMethod = model.OrderAdd.IdPaymentMethod;
                orderAdd.ChangeFor = model.OrderAdd.ChangeFor;
                orderAdd.CustomerAddress = model.OrderAdd.CustomerAddress;
                orderAdd.CustomerName = model.OrderAdd.CustomerName;
                orderAdd.CustomerPhone = model.OrderAdd.CustomerPhone;
                orderAdd.IdUserCreate = model.OrderAdd.IdUserCreate;
                orderAdd.IdUserEdit = model.OrderAdd.IdUserEdit;
                orderAdd.IdRestaurant = model.OrderAdd.IdRestaurant;
                orderAdd.TotalOrder = 0;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44378/api/Order/v1/OrderAddAsync", orderAdd);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return 0;

                string dataResponse = await response.Content.ReadAsStringAsync();

                JArray jsonArray = JArray.Parse(dataResponse);

                dynamic dResponse = JObject.Parse(jsonArray[0].ToString());

                idOrder = Convert.ToInt32(dResponse.idOrder);
            }

            return idOrder;
        }

        public async Task<bool> EditOrderAsync(OrderViewModel model)
        {
            OrderEditViewModel orderEdit = new OrderEditViewModel();

            bool success = false;

            if (model.OrderAdd.Status == "Confirmed")
            {
                orderEdit.IdOrder = model.OrderAdd.IdOrder;
                orderEdit.Active = true;
                orderEdit.EditDateTime = DateTime.Now;
                orderEdit.Status = model.OrderAdd.Status;
                orderEdit.LinkOrder = model.OrderAdd.LinkOrder;
                orderEdit.IdPaymentMethod = model.OrderAdd.IdPaymentMethod;
                orderEdit.ChangeFor = model.OrderAdd.ChangeFor;
                orderEdit.CustomerAddress = model.OrderAdd.CustomerAddress;
                orderEdit.CustomerName = model.OrderAdd.CustomerName;
                orderEdit.CustomerPhone = model.OrderAdd.CustomerPhone;
                orderEdit.IdUserEdit = model.OrderAdd.IdUserEdit;
                orderEdit.IdRestaurant = model.OrderAdd.IdRestaurant;
                orderEdit.TotalOrder = model.OrderAdd.TotalOrder;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44378/api/Order/v1/OrderEditAsync", orderEdit);

                success = response.StatusCode == HttpStatusCode.OK;
            }

            return success;
        }

        public async Task<bool> OrderUpdateStatusAsync(OrderUpdateStatusViewModel orderUpdateStatus)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44378/api/Order/v1/OrderUpdateStatusAsync", orderUpdateStatus);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<List<GetOrderListViewModel>> GetOrderListAsync(int idRestaurant, DateTime dateFrom, DateTime dateTo, string orderStatus)
        {
            string strDateFrom = dateFrom.ToString("yyyy-MM-ddT00:00:00Z");
            string strDateTo = dateTo.ToString("yyyy-MM-ddT23:59:59Z");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.GetAsync($"https://localhost:44378/api/Order/v1/GetOrderListAsync?IdRestaurant={ idRestaurant }&DateFrom={ strDateFrom }&DateTo={ strDateTo }&OrderStatus={ orderStatus }");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();

                var responseGetOrderList = JsonConvert.DeserializeObject<List<GetOrderListViewModel>>(data);

                return responseGetOrderList;
            }
            else
                return new List<GetOrderListViewModel>();            
        }
    }
}