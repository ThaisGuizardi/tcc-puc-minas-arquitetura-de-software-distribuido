using MenuFacile.Manager.Domain.DTO.Request.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface ISegmentService
    {
        Task<IEnumerable<T>> SegmentAdd<T>(T response, SegmentAddRequest request);

        Task<IEnumerable<T>> SegmentList<T>(T response);

        Task<IEnumerable<T>> SegmentEdit<T>(T response, SegmentEditRequest request);

        Task<IEnumerable<T>> SegmentDelete<T>(T response, SegmentBaseRequest request);

        Task<T> GetSegmentByIdAsync<T>(T response, SegmentBaseRequest request);

        Task<IEnumerable<T>> GetActiveSegmentsDropdownAsync<T>(T response);
    }
}
