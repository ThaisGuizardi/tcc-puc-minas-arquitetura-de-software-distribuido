using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Segment;
using MenuFacile.Manager.Domain.DTO.Response.Segment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        [HttpPost("v1/segmentaddasync")]
        public async Task<IActionResult> Post([FromHeader] string authorization, [FromServices] ISegmentService service, [FromBody] SegmentAddRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.SegmentAdd(new SegmentAddResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/segmentlistasync")]
        public async Task<IActionResult> Get([FromHeader] string authorization, [FromServices] ISegmentService service )
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.SegmentList(new SegmentListResponse());

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpPut("v1/segmenteditasync")]
        public async Task<IActionResult> Put([FromHeader] string authorization, [FromServices] ISegmentService service, [FromBody] SegmentEditRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.SegmentEdit(new SegmentBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpDelete("v1/segmentdeleteasync")]
        public async Task<IActionResult> Delete([FromHeader] string authorization, [FromServices] ISegmentService service, [FromQuery] SegmentBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.SegmentDelete(new SegmentBaseResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getsegmentbyidasync")]
        public async Task<IActionResult> GetSegmentByIdAsync([FromHeader] string authorization, [FromServices] ISegmentService service, [FromQuery] SegmentBaseRequest request)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                GetSegmentByIdResponse response = await service.GetSegmentByIdAsync(new GetSegmentByIdResponse(), request);

                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }

        [HttpGet("v1/getactivesegmentsdropdownasync")]
        public async Task<IActionResult> GetActiveSegmentsDropdownAsync([FromHeader] string authorization, [FromServices] ISegmentService service)
        {
            IActionResult result;

            if (string.IsNullOrEmpty(authorization))
                return Unauthorized();

            try
            {
                var response = await service.GetActiveSegmentsDropdownAsync(new GetActiveSegmentsDropdownResponse());

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
