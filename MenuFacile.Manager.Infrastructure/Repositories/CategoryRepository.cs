using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.Category;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<IEnumerable<T>> CategoryAdd<T>(T response, CategoryAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Description = request.Description });
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

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "cat_CategoryAdd");
        }

        public async Task<IEnumerable<T>> CategoryList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "cat_CategoryList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> CategoryEdit<T>(T response, CategoryEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdCategory = request.IdCategory });
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Description = request.Description });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "cat_CategoryEdit");
        }

        public async Task<IEnumerable<T>> CategoryDelete<T>(T response, CategoryBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdCategory = request.IdCategory });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "cat_CategoryDelete");
        }

        public async Task<T> GetCategoryByIdAsync<T>(T response, CategoryBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdCategory = request.IdCategory });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "cat_GetCategoryById");
        }
    }
}
