using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.RestaurantUser;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class RestaurantUserRepository : IRestaurantUserRepository
    {
        public async Task<IEnumerable<T>> RestaurantUserAdd<T>(T response, RestaurantUserAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @IdUser = request.IdUser });
                parameters.AddDynamicParams(new { @CreateDateTime = request.CreateDateTime });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserCreate = request.IdUserCreate });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "rus_RestaurantUserAdd");
        }

        public async Task<T> GetRestaurantByUserIdAsync<T>(T response, GetRestaurantByUserIdRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @UserId = request.UserId });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "rus_GetRestaurantByUserId");
        }
    }
}
