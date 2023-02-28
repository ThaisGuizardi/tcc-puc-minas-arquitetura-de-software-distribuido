using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.PaymentMethod;
using MenuFacile.Mvc.Services.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Controllers.Manager
{
    public class PaymentMethodController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<PaymentMethodController> _logger;

        public PaymentMethodController(ILogger<PaymentMethodController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentMethodAdd()
        {
            try
            {
                ViewBag.Restaurants = new SelectList(await new RestaurantService().RestaurantListAsync(), "IdRestaurant", "Name");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/PaymentMethod/PaymentMethodAdd.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> PaymentMethodAdd(string submitButton, PaymentMethodAddViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.CreateDateTime = DateTime.Now;
                    model.EditDateTime = DateTime.Now;
                    model.IdUserCreate = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/PaymentMethod/v1/PaymentMethodaddasync", model);

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        return View("~/Views/Shared/Unauthorized.cshtml");
                }
            }
            catch (Exception ex)
            {

                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("PaymentMethodList");
        }

        [HttpGet]
        public async Task<IActionResult> PaymentMethodList()
        {
            IEnumerable<PaymentMethodListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/PaymentMethod/v1/PaymentMethodlistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<PaymentMethodListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/PaymentMethod/PaymentMethodList.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> PaymentMethodEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/PaymentMethod/v1/getPaymentMethodbyidasync?IdPaymentMethod={ id }");

                if (response.IsSuccessStatusCode)
                {

                    string data = await response.Content.ReadAsStringAsync();

                    PaymentMethodEditViewModel model = JsonConvert.DeserializeObject<PaymentMethodEditViewModel>(data);

                    model.IdPaymentMethod = id;

                    ViewBag.Restaurants = new SelectList(await new RestaurantService().RestaurantListAsync(), "IdRestaurant", "Name", model.IdRestaurant);

                    return View("~/Views/Manager/PaymentMethod/PaymentMethodEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("PaymentMethodList");
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
        public async Task<IActionResult> PaymentMethodEdit(string submitButton, PaymentMethodEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/PaymentMethod/v1/PaymentMethodeditasync", model);

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        return View("~/Views/Shared/Unauthorized.cshtml");
                }
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("PaymentMethodList");
        }

        [HttpPost]
        public async Task<IActionResult> PaymentMethodDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/PaymentMethod/v1/PaymentMethoddeleteasync?IdPaymentMethod={ id }");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("PaymentMethodList");
        }
    }
}
