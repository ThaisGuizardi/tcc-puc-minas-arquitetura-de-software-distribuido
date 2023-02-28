using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Category;
using MenuFacile.Manager.Domain.DTO.Response.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpPost("v1/categoryaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] ICategoryService service, [FromBody] CategoryAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.CategoryAdd(new CategoryAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/categorylistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] ICategoryService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.CategoryList(new CategoryListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/categoryeditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] ICategoryService service, [FromBody] CategoryEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.CategoryEdit(new CategoryBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/categorydeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] ICategoryService service, [FromQuery] CategoryBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.CategoryDelete(new CategoryBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getcategorybyidasync")]
        public async Task<IActionResult> GetCategoryByIdAsync([FromHeader] string authorization, [FromServices] ICategoryService service, [FromQuery] CategoryBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetCategoryByIdResponse response = await service.GetCategoryByIdAsync(new GetCategoryByIdResponse(), request);

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
