using MenuFacile.Order.Domain.DTO.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Domain.Contracts.Services
{
    public interface IOrderItemService
    {
        Task<IEnumerable<T>> OrderItemAdd<T>(T response, IEnumerable<OrderItemAddRequest> request);
    }
}
