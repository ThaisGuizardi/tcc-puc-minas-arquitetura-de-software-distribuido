using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.ProductItem;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class ProductItemRepository : IProductItemRepository
    {
        public async Task<IEnumerable<T>> ProductItemAdd<T>(T response, ProductItemAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { IdProduct = request.IdProduct });
                parameters.AddDynamicParams(new { @Description = request.Description });
                parameters.AddDynamicParams(new { @Image = request.Image });
                parameters.AddDynamicParams(new { @NumberPeopleServing = request.NumberPeopleServing });
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

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "pit_ProductItemAdd");
        }

        public async Task<IEnumerable<T>> ProductItemList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "pit_ProductItemList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> ProductItemEdit<T>(T response, ProductItemEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductItem = request.IdProductItem });
                parameters.AddDynamicParams(new { IdProduct = request.IdProduct });
                parameters.AddDynamicParams(new { @Description = request.Description });
                parameters.AddDynamicParams(new { @Image = request.Image });
                parameters.AddDynamicParams(new { @NumberPeopleServing = request.NumberPeopleServing });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "pit_ProductItemEdit");
        }

        public async Task<IEnumerable<T>> ProductItemDelete<T>(T response, ProductItemBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductItem = request.IdProductItem });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "pit_ProductItemDelete");
        }

        public async Task<T> GetProductItemByIdAsync<T>(T response, ProductItemBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductItem = request.IdProductItem });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "pit_GetProductItemById");
        }
    }
}
