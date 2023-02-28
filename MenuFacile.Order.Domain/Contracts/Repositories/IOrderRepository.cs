using MenuFacile.Order.Domain.DTO.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<T>> GetListCurrentProductsByIdRestaurantAsync<T>(T response, GetListCurrentProductsByIdRestaurantRequest request);

        Task<T> GetOrderRestaurantAsync<T>(T response, OrderBaseRequest request);

        Task<IEnumerable<T>> GetPaymentMethodsByIdRestaurantAsync<T>(T response, OrderBaseRequest request);

        Task<IEnumerable<T>> OrderAdd<T>(T response, OrderAddRequest request);

        Task<IEnumerable<T>> OrderEdit<T>(T response, OrderEditRequest request);

        Task<IEnumerable<T>> GetOrderListAsync<T>(T response, GetOrderListRequest request);

        Task<IEnumerable<T>> OrderUpdateStatusAsync<T>(T response, OrderUpdateStatusRequest request);

        Task<IEnumerable<T>> GetOrderDetailAsync<T>(T response, GetOrderDetailRequest request);
    }
}
