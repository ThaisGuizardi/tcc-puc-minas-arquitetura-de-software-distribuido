using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.MenuItem;
using MenuFacile.Manager.Domain.DTO.Response.MenuItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuItemFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        [HttpPost("v1/menuItemaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IMenuItemService service, [FromBody] MenuItemAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuItemAdd(new MenuItemAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/menuItemlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IMenuItemService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuItemList(new MenuItemListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/menuItemeditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IMenuItemService service, [FromBody] MenuItemEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuItemEdit(new MenuItemBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/menuItemdeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IMenuItemService service, [FromQuery] MenuItemBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.MenuItemDelete(new MenuItemBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getMenuItembyidasync")]
        public async Task<IActionResult> GetMenuItemByIdAsync([FromHeader] string authorization, [FromServices] IMenuItemService service, [FromQuery] MenuItemBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetMenuItemByIdResponse response = await service.GetMenuItemByIdAsync(new GetMenuItemByIdResponse(), request);

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
