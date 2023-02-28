using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.City;
using MenuFacile.Manager.Domain.DTO.Response.City;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet("v1/getcitiesbyidstateasync")]
        public async Task<IActionResult> GetCitiesByIdStateAsync([FromHeader] string authorization, [FromServices] ICityService service, [FromQuery] GetCitiesByIdStateRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetCitiesByIdStateAsync(new GetCitiesByIdStateResponse(), request);

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
