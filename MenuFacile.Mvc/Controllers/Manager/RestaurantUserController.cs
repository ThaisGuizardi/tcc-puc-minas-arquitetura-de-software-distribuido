using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Models.Manager.RestaurantUser;
using MenuFacile.Mvc.Services.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Controllers.Manager
{
    public class RestaurantUserController : Controller
    {
        static HttpClient client = new HttpClient();

        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<RestaurantUserController> _logger;

        public RestaurantUserController(UserManager<IdentityUser> userManager, ILogger<RestaurantUserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> RestaurantUserAdd()
        {
            try
            {
                ViewBag.Restaurants = new SelectList(await new RestaurantService().RestaurantListAsync(), "IdRestaurant", "Name");

                ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName");
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View("~/Views/Manager/RestaurantUser/RestaurantUserAdd.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> RestaurantUserAdd(string submitButton, RestaurantUserAddViewModel model)
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

                    HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/RestaurantUser/v1/restaurantuseraddasync", model);

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

            return RedirectToAction("RestaurantUserList");
        }

        [HttpGet]
        public IActionResult RestaurantUserList()
        {
            try
            {
                return View("~/Views/Manager/RestaurantUser/RestaurantUserList.cshtml");
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
