using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _repository;

        public StateService(IStateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetStatesAsync<T>(T response)
        {
            return await _repository.GetStatesAsync(response);
        }
    }
}
