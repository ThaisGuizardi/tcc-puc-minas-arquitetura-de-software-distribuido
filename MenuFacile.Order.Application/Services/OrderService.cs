using MenuFacile.Order.Domain.Contracts.Repositories;
using MenuFacile.Order.Domain.Contracts.Services;
using MenuFacile.Order.Domain.DTO.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetListCurrentProductsByIdRestaurantAsync<T>(T response, GetListCurrentProductsByIdRestaurantRequest request)
        {
            return await _repository.GetListCurrentProductsByIdRestaurantAsync(response, request);
        }

        public async Task<T> GetOrderRestaurantAsync<T>(T response, OrderBaseRequest request)
        {
            return await _repository.GetOrderRestaurantAsync(response, request);
        }

        public async Task<IEnumerable<T>> GetPaymentMethodsByIdRestaurantAsync<T>(T response, OrderBaseRequest request)
        {
            return await _repository.GetPaymentMethodsByIdRestaurantAsync(response, request);
        }

        public async Task<IEnumerable<T>> OrderAdd<T>(T response, OrderAddRequest request)
        {
            return await _repository.OrderAdd(response, request);
        }

        public async Task<IEnumerable<T>> OrderEdit<T>(T response, OrderEditRequest request)
        {
            return await _repository.OrderEdit(response, request);
        }

        public async Task<IEnumerable<T>> GetOrderListAsync<T>(T response, GetOrderListRequest request)
        {
            return await _repository.GetOrderListAsync(response, request);
        }

        public async Task<IEnumerable<T>> OrderUpdateStatusAsync<T>(T response, OrderUpdateStatusRequest request)
        {
            return await _repository.OrderUpdateStatusAsync(response, request);
        }

        public async Task<IEnumerable<T>> GetOrderDetailAsync<T>(T response, GetOrderDetailRequest request)
        {
            return await _repository.GetOrderDetailAsync(response, request);
        }
    }
}
