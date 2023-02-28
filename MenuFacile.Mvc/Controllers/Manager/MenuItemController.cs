using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.MenuItem;
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
    public class MenuItemController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<MenuItemController> _logger;

        public MenuItemController(ILogger<MenuItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> MenuItemAdd()
        {
            try
            {
                ViewBag.Menus = new SelectList(await new MenuService().MenuListAsync(), "IdMenu", "Name");
                ViewBag.Products = new SelectList(await new ProductService().ProductListAsync(), "IdProduct", "Name");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
            
            return View("~/Views/Manager/MenuItem/MenuItemAdd.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> MenuItemList()
        {
            IEnumerable<MenuItemListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/MenuItem/v1/MenuItemlistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<MenuItemListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }
            
            return View("~/Views/Manager/MenuItem/MenuItemList.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> MenuItemAdd(string submitButton, MenuItemAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/MenuItem/v1/MenuItemaddasync", model);

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
            
            return RedirectToAction("MenuItemList");
        }

        [HttpGet]
        public async Task<IActionResult> MenuItemEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/MenuItem/v1/getMenuItembyidasync?IdMenuItem={ id }");

                if (response.IsSuccessStatusCode)
                {

                    string data = await response.Content.ReadAsStringAsync();

                    MenuItemEditViewModel model = JsonConvert.DeserializeObject<MenuItemEditViewModel>(data);

                    model.IdMenuItem = id;

                    ViewBag.Menus = new SelectList(await new MenuService().MenuListAsync(), "IdMenu", "Name", model.IdMenu);
                    ViewBag.Products = new SelectList(await new ProductService().ProductListAsync(), "IdProduct", "Name", model.IdProduct);


                    return View("~/Views/Manager/MenuItem/MenuItemEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("MenuItemList");
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
        public async Task<IActionResult> MenuItemEdit(string submitButton, MenuItemEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/MenuItem/v1/MenuItemeditasync", model);

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

            return RedirectToAction("MenuItemList");
        }

        [HttpPost]
        public async Task<IActionResult> MenuItemDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/MenuItem/v1/MenuItemdeleteasync?IdMenuItem={ id }");
            }
            catch (Exception ex)
            {

                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("MenuItemList");
        }
    }
}
