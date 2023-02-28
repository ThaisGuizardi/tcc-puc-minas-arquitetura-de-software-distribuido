using MenuFacile.Mvc.Models;
using MenuFacile.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MenuFacile.Mvc.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserInfoViewModel.Token);

                HttpResponseMessage response = await client.GetAsync($"https://localhost:44373/api/RestaurantUser/v1/GetRestaurantByUserIdAsync?UserId={ User.FindFirstValue(ClaimTypes.NameIdentifier) }");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    return View("~/Views/Shared/Unauthorized.cshtml");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    GetRestaurantByUserIdViewModel model = JsonConvert.DeserializeObject<GetRestaurantByUserIdViewModel>(data);

                    var userIdentity = (ClaimsIdentity)User.Identity;
                    var claims = userIdentity.Claims;
                    var role = claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault().Value;  

                    UserInfoViewModel.IdUser = model.IdUser;
                    UserInfoViewModel.IdRestaurant = model.IdRestaurant;
                    UserInfoViewModel.UserRole = role;
                    UserInfoViewModel.UserName = userIdentity.Name;
                    UserInfoViewModel.Token = TokenService.GenerateToken();
                }
            }
            catch (Exception ex)
            {
                string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                _logger.LogError($"Error Message: { ex.Message } / Action: { actionName } / Controller: { controllerName } / User Name: { User.Identity.Name }");

                throw new Exception(ex.Message);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
