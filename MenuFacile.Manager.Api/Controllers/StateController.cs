using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Response.State;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        [HttpGet("v1/getstatesasync")]
        public async Task<IActionResult> GetStatesAsync([FromHeader] string authorization, [FromServices] IStateService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetStatesAsync(new GetStatesResponse());

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
