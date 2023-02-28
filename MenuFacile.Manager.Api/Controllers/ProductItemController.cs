using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.ProductItem;
using MenuFacile.Manager.Domain.DTO.Response.ProductItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        [HttpPost("v1/productitemaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IProductItemService service, [FromBody] ProductItemAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductItemAdd(new ProductItemAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/productitemlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IProductItemService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductItemList(new ProductItemListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/productitemeditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IProductItemService service, [FromBody] ProductItemEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductItemEdit(new ProductItemBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/productitemdeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IProductItemService service, [FromQuery] ProductItemBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductItemDelete(new ProductItemBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getproductitembyidasync")]
        public async Task<IActionResult> GetProductItemByIdAsync([FromHeader] string authorization, [FromServices] IProductItemService service, [FromQuery] ProductItemBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetProductItemByIdResponse response = await service.GetProductItemByIdAsync(new GetProductItemByIdResponse(), request);

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
