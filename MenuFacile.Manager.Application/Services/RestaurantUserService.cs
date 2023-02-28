using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.RestaurantUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class RestaurantUserService : IRestaurantUserService
    {
        private readonly IRestaurantUserRepository _repository;

        public RestaurantUserService(IRestaurantUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> RestaurantUserAdd<T>(T response, RestaurantUserAddRequest request)
        {
            return await _repository.RestaurantUserAdd(response, request);
        }

        public async Task<T> GetRestaurantByUserIdAsync<T>(T response, GetRestaurantByUserIdRequest request)
        {
            return await _repository.GetRestaurantByUserIdAsync(response, request);
        }
    }
}
