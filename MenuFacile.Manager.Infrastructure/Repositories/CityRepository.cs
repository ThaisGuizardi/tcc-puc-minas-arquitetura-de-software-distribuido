using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.City;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        public async Task<IEnumerable<T>> GetCitiesByIdStateAsync<T>(T response, GetCitiesByIdStateRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdState = request.IdState });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetListByProcedure<T>(response, parameters, "cit_GetCitiesByIdState");
        }
    }
}
