using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.PaymentMethod;
using MenuFacile.Manager.Domain.DTO.Response.PaymentMethod;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        [HttpPost("v1/paymentmethodaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] IPaymentMethodService service, [FromBody] PaymentMethodAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.PaymentMethodAdd(new PaymentMethodAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/paymentmethodlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] IPaymentMethodService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.PaymentMethodList(new PaymentMethodListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/paymentmethodeditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] IPaymentMethodService service, [FromBody] PaymentMethodEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.PaymentMethodEdit(new PaymentMethodBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/paymentmethoddeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] IPaymentMethodService service, [FromQuery] PaymentMethodBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.PaymentMethodDelete(new PaymentMethodBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getPaymentMethodbyidasync")]
        public async Task<IActionResult> GetPaymentMethodByIdAsync([FromHeader] string authorization, [FromServices] IPaymentMethodService service, [FromQuery] PaymentMethodBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetPaymentMethodByIdResponse response = await service.GetPaymentMethodByIdAsync(new GetPaymentMethodByIdResponse(), request);

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
