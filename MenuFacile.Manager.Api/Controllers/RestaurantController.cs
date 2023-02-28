using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Restaurant;
using MenuFacile.Manager.Domain.DTO.Response.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        [HttpPost("v1/restaurantaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IRestaurantService service, [FromBody] RestaurantAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.RestaurantAdd(new RestaurantAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/restaurantlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IRestaurantService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.RestaurantList(new RestaurantListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/restauranteditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IRestaurantService service, [FromBody] RestaurantEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.RestaurantEdit(new RestaurantBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/restaurantdeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IRestaurantService service, [FromQuery] RestaurantBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.RestaurantDelete(new RestaurantBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getrestaurantbyidasync")]
        public async Task<IActionResult> GetRestaurantByIdAsync([FromHeader] string authorization, [FromServices] IRestaurantService service, [FromQuery] RestaurantBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetRestaurantByIdResponse response = await service.GetRestaurantByIdAsync(new GetRestaurantByIdResponse(), request);

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
