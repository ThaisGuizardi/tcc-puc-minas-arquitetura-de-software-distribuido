using MenuFacile.Order.Domain.Contracts.Repositories;
using MenuFacile.Order.Domain.Contracts.Services;
using MenuFacile.Order.Domain.DTO.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> OrderItemAdd<T>(T response, IEnumerable<OrderItemAddRequest> request)
        {
            return await _repository.OrderItemAdd(response, request);
        }
    }
}
