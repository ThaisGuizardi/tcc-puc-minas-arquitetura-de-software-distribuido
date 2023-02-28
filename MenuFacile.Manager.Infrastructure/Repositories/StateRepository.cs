using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        public async Task<IEnumerable<T>> GetStatesAsync<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "sta_GetStates");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
