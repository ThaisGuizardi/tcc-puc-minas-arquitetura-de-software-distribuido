using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> RestaurantAdd<T>(T response, RestaurantAddRequest request)
        {
            return await _repository.RestaurantAdd(response, request);
        }

        public async Task<IEnumerable<T>> RestaurantList<T>(T response)
        {
            return await _repository.RestaurantList(response);
        }

        public async Task<IEnumerable<T>> RestaurantEdit<T>(T response, RestaurantEditRequest request)
        {
            return await _repository.RestaurantEdit(response, request);
        }

        public async Task<IEnumerable<T>> RestaurantDelete<T>(T response, RestaurantBaseRequest request)
        {
            return await _repository.RestaurantDelete(response, request);
        }

        public async Task<T> GetRestaurantByIdAsync<T>(T response, RestaurantBaseRequest request)
        {
            return await _repository.GetRestaurantByIdAsync(response, request);
        }
    }
}
