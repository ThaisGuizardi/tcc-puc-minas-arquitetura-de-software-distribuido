using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Product;
using MenuFacile.Manager.Domain.DTO.Response.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("v1/productaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IProductService service, [FromBody] ProductAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductAdd(new ProductAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/productlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IProductService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductList(new ProductListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/producteditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IProductService service, [FromBody] ProductEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductEdit(new ProductBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/productdeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IProductService service, [FromQuery] ProductBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.ProductDelete(new ProductBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getproductbyidasync")]
        public async Task<IActionResult> GetProductByIdAsync([FromHeader] string authorization, [FromServices] IProductService service, [FromQuery] ProductBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetProductByIdResponse response = await service.GetProductByIdAsync(new GetProductByIdResponse(), request);

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
