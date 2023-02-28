using MenuFacile.Manager.Domain.DTO.Request.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Domain.Contracts.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<T>> GetCitiesByIdStateAsync<T>(T response, GetCitiesByIdStateRequest request);
    }
}
