using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.Category;
using MenuFacile.Mvc.Services;
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
    public class CategoryController : Controller
    {
        static HttpClient client = new HttpClient();  

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAdd()
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

            return View("~/Views/Manager/Category/CategoryAdd.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            IEnumerable<CategoryListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/Category/v1/Categorylistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<CategoryListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/Category/CategoryList.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAdd(string submitButton, CategoryAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/Category/v1/Categoryaddasync", model);

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

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/Category/v1/getCategorybyidasync?IdCategory={ id }");

                if (response.IsSuccessStatusCode)
                {

                    string data = await response.Content.ReadAsStringAsync();

                    CategoryEditViewModel model = JsonConvert.DeserializeObject<CategoryEditViewModel>(data);

                    model.IdCategory = id;

                    ViewBag.Restaurants = new SelectList(await new RestaurantService().RestaurantListAsync(), "IdRestaurant", "Name", model.IdRestaurant);

                    return View("~/Views/Manager/Category/CategoryEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("CategoryList");
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
        public async Task<IActionResult> CategoryEdit(string submitButton, CategoryEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/Category/v1/Categoryeditasync", model);

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

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/Category/v1/Categorydeleteasync?IdCategory={ id }");

                return RedirectToAction("CategoryList");
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
