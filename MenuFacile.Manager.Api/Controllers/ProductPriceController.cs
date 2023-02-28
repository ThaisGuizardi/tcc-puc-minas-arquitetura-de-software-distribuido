using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.ProductPrice;
using MenuFacile.Manager.Domain.DTO.Response.ProductPrice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        [HttpPost("v1/productpriceaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IProductPriceService service, [FromBody] ProductPriceAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductPriceAdd(new ProductPriceAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/productpricelistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IProductPriceService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductPriceList(new ProductPriceListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/productpriceeditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IProductPriceService service, [FromBody] ProductPriceEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductPriceEdit(new ProductPriceBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/productpricedeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IProductPriceService service, [FromQuery] ProductPriceBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductPriceDelete(new ProductPriceBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getProductPricebyidasync")]
        public async Task<IActionResult> GetProductPriceByIdAsync([FromHeader] string authorization, [FromServices] IProductPriceService service, [FromQuery] ProductPriceBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetProductPriceByIdResponse response = await service.GetProductPriceByIdAsync(new GetProductPriceByIdResponse(), request);

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
