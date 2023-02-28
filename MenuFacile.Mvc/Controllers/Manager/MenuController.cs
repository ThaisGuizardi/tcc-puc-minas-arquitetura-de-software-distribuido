using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Menu;
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
    public class MenuController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MenuAdd()
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

            return View("~/Views/Manager/Menu/MenuAdd.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> MenuList()
        {
            IEnumerable<MenuListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Menu/v1/Menulistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<MenuListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/Menu/MenuList.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> MenuAdd(string submitButton, MenuAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/Menu/v1/Menuaddasync", model);

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
            
            return RedirectToAction("MenuList");
        }

        [HttpGet]
        public async Task<IActionResult> MenuEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/Menu/v1/getMenubyidasync?IdMenu={ id }");

                if (response.IsSuccessStatusCode)
                {

                    string data = await response.Content.ReadAsStringAsync();

                    MenuEditViewModel model = JsonConvert.DeserializeObject<MenuEditViewModel>(data);

                    model.IdMenu = id;

                    ViewBag.Restaurants = new SelectList(await new RestaurantService().RestaurantListAsync(), "IdRestaurant", "Name", model.IdRestaurant);

                    return View("~/Views/Manager/Menu/MenuEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("MenuList");
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
        public async Task<IActionResult> MenuEdit(string submitButton, MenuEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/Menu/v1/Menueditasync", model);

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
            
            return RedirectToAction("MenuList");
        }

        [HttpPost]
        public async Task<IActionResult> MenuDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/Menu/v1/Menudeleteasync?IdMenu={ id }");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
            
            return RedirectToAction("MenuList");
        }
    }
}
