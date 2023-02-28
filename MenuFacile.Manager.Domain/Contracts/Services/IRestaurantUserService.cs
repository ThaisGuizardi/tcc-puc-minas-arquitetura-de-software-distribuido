using MenuFacile.Manager.Domain.DTO.Request.RestaurantUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Services
{
    public interface IRestaurantUserService
    {
        Task<IEnumerable<T>> RestaurantUserAdd<T>(T response, RestaurantUserAddRequest request);

        Task<T> GetRestaurantByUserIdAsync<T>(T response, GetRestaurantByUserIdRequest request);
    }
}
