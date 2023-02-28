using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.RestaurantUser;
using MenuFacile.Manager.Domain.DTO.Response.RestaurantUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantUserController : ControllerBase
    {
        [HttpPost("v1/restaurantuseraddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IRestaurantUserService service, [FromBody] RestaurantUserAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.RestaurantUserAdd(new RestaurantUserAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/GetRestaurantByUserIdAsync")]
        public async Task<IActionResult> GetRestaurantByUserIdAsync([FromServices] IRestaurantUserService service, [FromQuery] GetRestaurantByUserIdRequest request)
        {
            IActionResult result;

            try
            {
                GetRestaurantByUserIdResponse response = await service.GetRestaurantByUserIdAsync(new GetRestaurantByUserIdResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }
    }
}
