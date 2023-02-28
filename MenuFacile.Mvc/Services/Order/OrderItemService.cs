using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Order.Dashboard;
using MenuFacile.Mvc.Models.Order.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Services.OrderItem
{
    public class OrderItemService
    {
        static HttpClient client = new HttpClient();

        public async Task<bool> AddOrderItemAsync(List<GetListCurrentProductsByIdRestaurantViewModel> listProducts, int idOrder)
        {
            OrderItemAddViewModel orderItemAdd = new OrderItemAddViewModel();
            List<OrderItemAddViewModel> listOrderItemAdd = new List<OrderItemAddViewModel>();

            foreach (var item in listProducts.FindAll(p => p.Qty > 0).ToList())
            {
                orderItemAdd = new OrderItemAddViewModel();

                orderItemAdd.Active = true;
                orderItemAdd.CreateDateTime = DateTime.Now;
                orderItemAdd.EditDateTime = DateTime.Now;
                orderItemAdd.IdOrder = idOrder;
                orderItemAdd.IdProduct = item.IdProduct;
                orderItemAdd.IdUserCreate = string.Empty;
                orderItemAdd.IdUserEdit = string.Empty;
                orderItemAdd.ProductPrice = item.Price;
                orderItemAdd.Qty = item.Qty;

                listOrderItemAdd.Add(orderItemAdd);
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44378/api/OrderItem/v1/OrderItemAddAsync", listOrderItemAdd);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                return false;

            return true;
        }
    }
}
