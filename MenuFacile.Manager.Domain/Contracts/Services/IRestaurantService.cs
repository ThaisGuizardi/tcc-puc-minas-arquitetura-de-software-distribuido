using MenuFacile.Manager.Domain.DTO.Request.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<T>> RestaurantAdd<T>(T response, RestaurantAddRequest request);

        Task<IEnumerable<T>> RestaurantList<T>(T response);

        Task<IEnumerable<T>> RestaurantEdit<T>(T response, RestaurantEditRequest request);

        Task<IEnumerable<T>> RestaurantDelete<T>(T response, RestaurantBaseRequest request);

        Task<T> GetRestaurantByIdAsync<T>(T response, RestaurantBaseRequest request);
    }
}
