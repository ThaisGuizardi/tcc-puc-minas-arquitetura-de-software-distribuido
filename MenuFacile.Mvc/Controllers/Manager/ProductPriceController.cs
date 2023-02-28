using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.ProductPrice;
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
    public class ProductPriceController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<ProductPriceController> _logger;

        public ProductPriceController(ILogger<ProductPriceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ProductPriceAdd()
        {
            try
            {
                ViewBag.Products = new SelectList(await new ProductService().ProductListAsync(), "IdProduct", "Name");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/ProductPrice/ProductPriceAdd.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> ProductPriceAdd(string submitButton, ProductPriceAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/ProductPrice/v1/ProductPriceaddasync", model);

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

            return RedirectToAction("ProductPriceList");
        }

        [HttpGet]
        public async Task<IActionResult> ProductPriceList()
        {
            IEnumerable<ProductPriceListViewModel> model;

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync("https://localhost:44373/api/ProductPrice/v1/ProductPricelistasync");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                string data = await response.Content.ReadAsStringAsync();

                model = JsonConvert.DeserializeObject<IEnumerable<ProductPriceListViewModel>>(data);
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/ProductPrice/ProductPriceList.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductPriceEdit(int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/ProductPrice/v1/getProductPricebyidasync?IdProductPrice={ id }");

                if (response.IsSuccessStatusCode)
                {

                    string data = await response.Content.ReadAsStringAsync();

                    ProductPriceEditViewModel model = JsonConvert.DeserializeObject<ProductPriceEditViewModel>(data);

                    model.IdProductPrice = id;

                    ViewBag.Products = new SelectList(await new ProductService().ProductListAsync(), "IdProduct", "Name", model.IdProduct);

                    return View("~/Views/Manager/ProductPrice/ProductPriceEdit.cshtml", model);
                }
                else
                {
                    return RedirectToAction("ProductPriceList");
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
        public async Task<IActionResult> ProductPriceEdit(string submitButton, ProductPriceEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid && submitButton == "save")
                {
                    model.EditDateTime = DateTime.Now;
                    model.IdUserEdit = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token); 

                    HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/ProductPrice/v1/ProductPriceeditasync", model);

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

            return RedirectToAction("ProductPriceList");
        }

        [HttpPost]
        public async Task<IActionResult> ProductPriceDelete(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/ProductPrice/v1/ProductPricedeleteasync?IdProductPrice={ id }");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return RedirectToAction("ProductPriceList");
        }
    }
}
