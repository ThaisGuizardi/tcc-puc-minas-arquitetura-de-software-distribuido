using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class SegmentService : ISegmentService
    {
        private readonly ISegmentRepository _repository;

        public SegmentService(ISegmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> SegmentAdd<T>(T response, SegmentAddRequest request)
        {
            return await _repository.SegmentAdd(response, request);
        }

        public async Task<IEnumerable<T>> SegmentList<T>(T response)
        {
            return await _repository.SegmentList(response);
        }

        public async Task<IEnumerable<T>> SegmentEdit<T>(T response, SegmentEditRequest request)
        {
            return await _repository.SegmentEdit(response, request);
        }

        public async Task<IEnumerable<T>> SegmentDelete<T>(T response, SegmentBaseRequest request)
        {
            return await _repository.SegmentDelete(response, request);
        }

        public async Task<T> GetSegmentByIdAsync<T>(T response, SegmentBaseRequest request)
        {
            return await _repository.GetSegmentByIdAsync(response, request);
        }

        public async Task<IEnumerable<T>> GetActiveSegmentsDropdownAsync<T>(T response)
        {
            return await _repository.GetActiveSegmentsDropdownAsync(response);
        }
    }
}
