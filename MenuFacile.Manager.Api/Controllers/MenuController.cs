using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Menu;
using MenuFacile.Manager.Domain.DTO.Response.Menu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpPost("v1/menuaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IMenuService service, [FromBody] MenuAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuAdd(new MenuAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/menulistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IMenuService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuList(new MenuListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/menueditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IMenuService service, [FromBody] MenuEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuEdit(new MenuBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/menudeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IMenuService service, [FromQuery] MenuBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuDelete(new MenuBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getMenubyidasync")]
        public async Task<IActionResult> GetMenuByIdAsync([FromHeader] string authorization, [FromServices] IMenuService service, [FromQuery] MenuBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetMenuByIdResponse response = await service.GetMenuByIdAsync(new GetMenuByIdResponse(), request);

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
