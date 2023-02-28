using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.Menu;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        public async Task<IEnumerable<T>> MenuAdd<T>(T response, MenuAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @ValidFrom = request.ValidFrom });
                parameters.AddDynamicParams(new { @ValidTo = request.ValidTo });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @CreateDateTime = request.CreateDateTime });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserCreate = request.IdUserCreate });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "men_MenuAdd");
        }

        public async Task<IEnumerable<T>> MenuList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "men_MenuList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> MenuEdit<T>(T response, MenuEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenu = request.IdMenu });
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @ValidFrom = request.ValidFrom });
                parameters.AddDynamicParams(new { @ValidTo = request.ValidTo });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "men_MenuEdit");
        }

        public async Task<IEnumerable<T>> MenuDelete<T>(T response, MenuBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenu = request.IdMenu });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "men_MenuDelete");
        }

        public async Task<T> GetMenuByIdAsync<T>(T response, MenuBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenu = request.IdMenu });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "men_GetMenuById");
        }
    }
}
