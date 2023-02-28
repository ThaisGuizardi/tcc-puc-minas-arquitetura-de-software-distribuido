 using MenuFacile.Order.Domain.Contracts.Services;
using MenuFacile.Order.Domain.DTO.Request.Order;
using MenuFacile.Order.Domain.DTO.Response.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Threading.Tasks;

namespace MenuFacile.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("v1/GetListCurrentProductsByIdRestaurantAsync")]
        public async Task<IActionResult> GetListCurrentProductsByIdRestaurantAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromQuery] GetListCurrentProductsByIdRestaurantRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                request.ValidFrom = DateTime.Now;
                request.ValidUntil = DateTime.Now;

                var response = await service.GetListCurrentProductsByIdRestaurantAsync(new GetListCurrentProductsByIdRestaurantResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/GetOrderRestaurantAsync")]
        public async Task<IActionResult> GetOrderRestaurantAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromQuery] OrderBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetOrderRestaurantAsync(new GetOrderRestaurantResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/GetPaymentMethodsByIdRestaurantAsync")]
        public async Task<IActionResult> GetPaymentMethodsByIdRestaurantAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromQuery] OrderBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetPaymentMethodsByIdRestaurantAsync(new GetPaymentMethodsByIdRestaurantResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPost("v1/OrderAddAsync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IOrderService service, [FromBody] OrderAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.OrderAdd(new OrderAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/OrderEditAsync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IOrderService service, [FromBody] OrderEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.OrderEdit(new OrderBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/GetOrderListAsync")]
        public async Task<IActionResult> GetOrderListAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromQuery] GetOrderListRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetOrderListAsync(new GetOrderListResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/OrderUpdateStatusAsync")]
        public async Task<IActionResult> OrderUpdateStatusAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromBody] OrderUpdateStatusRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.OrderUpdateStatusAsync(new OrderBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/GetOrderDetailAsync")]
        public async Task<IActionResult> GetOrderDetailAsync([FromHeader] string authorization, [FromServices] IOrderService service, [FromQuery] GetOrderDetailRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetOrderDetailAsync(new GetOrderDetailResponse(), request);

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
