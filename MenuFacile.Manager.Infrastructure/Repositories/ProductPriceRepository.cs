using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.ProductPrice;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        public async Task<IEnumerable<T>> ProductPriceAdd<T>(T response, ProductPriceAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProduct = request.IdProduct });
                parameters.AddDynamicParams(new { @Price = request.Price });
                parameters.AddDynamicParams(new { @ValidFrom = request.ValidFrom });
                parameters.AddDynamicParams(new { @ValidUntil = request.ValidUntil });
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

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ppc_ProductPriceAdd");
        }

        public async Task<IEnumerable<T>> ProductPriceList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "ppc_ProductPriceList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> ProductPriceEdit<T>(T response, ProductPriceEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductPrice = request.IdProductPrice });
                parameters.AddDynamicParams(new { @IdProduct = request.IdProduct });
                parameters.AddDynamicParams(new { @Price = request.Price });
                parameters.AddDynamicParams(new { @ValidFrom = request.ValidFrom });
                parameters.AddDynamicParams(new { @ValidUntil = request.ValidUntil });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ppc_ProductPriceEdit");
        }

        public async Task<IEnumerable<T>> ProductPriceDelete<T>(T response, ProductPriceBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductPrice = request.IdProductPrice });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ppc_ProductPriceDelete");
        }

        public async Task<T> GetProductPriceByIdAsync<T>(T response, ProductPriceBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdProductPrice = request.IdProductPrice });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "ppc_GetProductPriceById");
        }
    }
}
