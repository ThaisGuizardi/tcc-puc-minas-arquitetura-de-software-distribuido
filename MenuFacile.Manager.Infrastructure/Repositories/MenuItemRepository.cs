using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.MenuItem;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        public async Task<IEnumerable<T>> MenuItemAdd<T>(T response, MenuItemAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenu = request.IdMenu });
                parameters.AddDynamicParams(new { @IdProduct = request.IdProduct });
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

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "mit_MenuItemAdd");
        }

        public async Task<IEnumerable<T>> MenuItemList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "mit_MenuItemList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> MenuItemEdit<T>(T response, MenuItemEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenuItem = request.IdMenuItem });
                parameters.AddDynamicParams(new { @IdMenu = request.IdMenu });
                parameters.AddDynamicParams(new { @IdProduct = request.IdProduct });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "mit_MenuItemEdit");
        }

        public async Task<IEnumerable<T>> MenuItemDelete<T>(T response, MenuItemBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenuItem = request.IdMenuItem });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "mit_MenuItemDelete");
        }

        public async Task<T> GetMenuItemByIdAsync<T>(T response, MenuItemBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdMenuItem = request.IdMenuItem });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "mit_GetMenuItemById");
        }
    }
}
