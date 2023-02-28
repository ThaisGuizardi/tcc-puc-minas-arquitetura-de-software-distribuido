using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Order.Dashboard;
using MenuFacile.Mvc.Services.Order;
using MenuFacile.Mvc.Services.OrderItem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Controllers.Order
{
    public class DashboardController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(int idRestaurant, string currentOrderStatus, DateTime dateFrom, DateTime dateTo)
        {
            DashboardViewModel model = new DashboardViewModel();

            try
            {
                model.GetOrderList = new List<GetOrderListViewModel>();

                if (string.IsNullOrEmpty(currentOrderStatus) && UserInfoViewModel.UserRole == "Cozinha")
                    currentOrderStatus = "Cooking";
                else if (string.IsNullOrEmpty(currentOrderStatus) && UserInfoViewModel.UserRole == "Entrega")
                    currentOrderStatus = "Delivering";

                model.IdRestaurant = idRestaurant > 0 ? idRestaurant : UserInfoViewModel.IdRestaurant;

                dateFrom = dateFrom == DateTime.MinValue ? DateTime.Now : dateFrom;
                dateTo = dateTo == DateTime.MinValue ? DateTime.Now : dateTo;

                model.GetOrderList = await new OrderService().GetOrderListAsync(model.IdRestaurant, dateFrom, dateTo, currentOrderStatus);

            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
            
            return View("~/Views/Order/Dashboard/Index.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string submitButton, int idRestaurant, string nextStatus, int idOrderNextStatus, DashboardViewModel modelDashboard)
        {
            try
            {
                bool orderUpdateStatusSuccess = false;

                switch (submitButton)
                {
                    case "submitPreOrder":

                        OrderViewModel model = new OrderViewModel();

                        model.OrderAdd = new OrderAddViewModel();

                        model.OrderAdd.Status = "PreOrder";
                        model.OrderAdd.LinkOrder = submitButton;
                        model.OrderAdd.IdRestaurant = idRestaurant;

                        int idOrder = await new OrderService().AddOrderAsync(model);

                        return RedirectToAction("OrderAdd", new { idRestaurant = idRestaurant, idOrder = idOrder });

                    case "submitNextStatus":

                        OrderUpdateStatusViewModel orderUpdateStatus = new OrderUpdateStatusViewModel();

                        orderUpdateStatus.IdOrder = idOrderNextStatus;
                        orderUpdateStatus.OrderStatus = nextStatus;

                        orderUpdateStatusSuccess = await new OrderService().OrderUpdateStatusAsync(orderUpdateStatus);

                        break;
                    case "submitOrderDetail":

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                        HttpResponseMessage response = await client.GetAsync($"https://localhost:44378/api/Order/v1/GetOrderDetailAsync?IdOrder={ idOrderNextStatus }");

                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();

                            List<GetOrderDetailViewModel> getOrderDetails = JsonConvert.DeserializeObject<List<GetOrderDetailViewModel>>(data);

                            return View("~/Views/Order/Dashboard/OrderDetail.cshtml", getOrderDetails);
                        }

                        break;

                    case "submitFilter":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = string.Empty, dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterPreOrder":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "PreOrder", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterConfirmed":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "Confirmed", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterCooking":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "Cooking", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterCooked":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "Cooked", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterDelivering":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "Delivering", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    case "filterDelivered":

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = "Delivered", dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });

                    default:

                        return RedirectToAction("Index", new { idRestaurant = idRestaurant, currentOrderStatus = string.Empty, dateFrom = modelDashboard.DateFrom, dateTo = modelDashboard.DateTo });
                }
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> OrderAdd(int idRestaurant, int idOrder)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage responseRestaurant = await client.GetAsync($"https://localhost:44378/api/Order/v1/GetOrderRestaurantAsync?IdRestaurant={ idRestaurant }");

                HttpResponseMessage responseProducts = await client.GetAsync($"https://localhost:44378/api/Order/v1/GetListCurrentProductsByIdRestaurantAsync?IdRestaurant={ idRestaurant }");

                if (responseRestaurant.IsSuccessStatusCode && responseProducts.IsSuccessStatusCode)
                {
                    string dataRestaurant = await responseRestaurant.Content.ReadAsStringAsync();

                    string dataProducts = await responseProducts.Content.ReadAsStringAsync();

                    OrderViewModel model = new OrderViewModel();

                    model.GetRestaurant = JsonConvert.DeserializeObject<GetOrderRestaurantViewModel>(dataRestaurant);

                    model.GetListCurrentProductsByIdRestaurant = JsonConvert.DeserializeObject<IEnumerable<GetListCurrentProductsByIdRestaurantViewModel>>(dataProducts);

                    ViewBag.PaymentMethods = new SelectList(await new OrderService().GetPaymentMethodsByIdRestaurantAsync(idRestaurant), "IdPaymentMethod", "Name");

                    model.OrderAdd = new OrderAddViewModel();
                    model.OrderAdd.IdRestaurant = idRestaurant;
                    model.OrderAdd.IdOrder = idOrder;

                    return View("~/Views/Order/Dashboard/OrderAdd.cshtml", model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderAdd(string submitButton, List<GetListCurrentProductsByIdRestaurantViewModel> listProducts, OrderViewModel model)
        {
            try
            {
                if (submitButton == "submitOrderConfirmed")
                {
                    model.OrderAdd.Status = "Confirmed";
                    model.OrderAdd.LinkOrder = submitButton;
                    model.OrderAdd.TotalOrder = listProducts.Where(p => p.Qty > 0).Select(p => (p.Price * p.Qty)).Sum();

                    bool success = await new OrderService().EditOrderAsync(model);

                    if (success)
                        success = await new OrderItemService().AddOrderItemAsync(listProducts, model.OrderAdd.IdOrder);
                }
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            try
            {
                return View("~/Views/Order/Dashboard/OrderSuccess.cshtml");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
        }
    }
}
