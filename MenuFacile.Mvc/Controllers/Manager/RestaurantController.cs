using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.City;
using MenuFacile.Mvc.Models.Manager.Restaurant;
using MenuFacile.Mvc.Models.Manager.Segment;
using MenuFacile.Mvc.Models.Manager.State;
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
    public class RestaurantController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantAdd()
        {
            try
            {
                ViewBag.Segments = new SelectList(await new SegmentService().GetActiveSegmentsDropdownAsync(), "IdSegment", "Name");
                ViewBag.States = new SelectList(await new StateService().GetStatesAsync(), "IdState", "Name");
                ViewBag.Cities = new SelectList(await new CityService().GetCitiesByIdStateAsync(26), "IdCity", "Name");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/Restaurant/RestaurantAdd.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> RestaurantAdd(string submitButton, RestaurantAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/Restaurant/v1/restaurantaddasync", model);

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

            return RedirectToAction("RestaurantList");
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantList()
        {
            IEnumerable<RestaurantListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Restaurant/v1/restaurantlistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<RestaurantListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
           
            return View("~/Views/Manager/Restaurant/RestaurantList.cshtml", model);
        }


        [HttpGet]
        public async Task<IActionResult> RestaurantEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/Restaurant/v1/getRestaurantbyidasync?IdRestaurant={ id }");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    RestaurantEditViewModel model = JsonConvert.DeserializeObject<RestaurantEditViewModel>(data);

                    model.IdRestaurant = id;

                    ViewBag.Segments = new SelectList(await new SegmentService().GetActiveSegmentsDropdownAsync(), "IdSegment", "Name", model.IdSegment);
                    ViewBag.States = new SelectList(await new StateService().GetStatesAsync(), "IdState", "Name", model.IdState);
                    ViewBag.Cities = new SelectList(await new CityService().GetCitiesByIdStateAsync(26), "IdCity", "Name", model.IdCity);

                    return View("~/Views/Manager/Restaurant/RestaurantEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("RestaurantList");
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
        public async Task<IActionResult> RestaurantEdit(string submitButton, RestaurantEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/restaurant/v1/restauranteditasync", model);

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

            return RedirectToAction("RestaurantList");
        }

        [HttpPost]
        public async Task<IActionResult> RestaurantDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/Restaurant/v1/restaurantdeleteasync?IdRestaurant={ id }");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("RestaurantList");
        }
    }
}
