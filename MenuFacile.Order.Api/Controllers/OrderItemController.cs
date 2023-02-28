using MenuFacile.Order.Domain.Contracts.Services;
using MenuFacile.Order.Domain.DTO.Request.OrderItem;
using MenuFacile.Order.Domain.DTO.Response.OrderItem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuFacile.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        [HttpPost("v1/OrderItemAddAsync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IOrderItemService service, [FromBody] IEnumerable<OrderItemAddRequest> request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.OrderItemAdd(new OrderItemAddResponse(), request);

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
