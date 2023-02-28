using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using MenuFacile.Manager.Domain.DTO.Request.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetCitiesByIdStateAsync<T>(T response, GetCitiesByIdStateRequest request)
        {
            return await _repository.GetCitiesByIdStateAsync(response, request);
        }
    }
}
