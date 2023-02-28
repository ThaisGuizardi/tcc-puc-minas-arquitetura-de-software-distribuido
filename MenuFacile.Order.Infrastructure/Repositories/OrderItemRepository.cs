using Dapper;
using MenuFacile.Manager.Infrastructure.Configuration;
using MenuFacile.Order.Domain.Contracts.Repositories;
using MenuFacile.Order.Domain.DTO.Request.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public async Task<IEnumerable<T>> OrderItemAdd<T>(T response, IEnumerable<OrderItemAddRequest> request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                foreach (var item in request)
                {
                    parameters.AddDynamicParams(new { @Active = item.Active });
                    parameters.AddDynamicParams(new { @CreateDateTime = item.CreateDateTime });
                    parameters.AddDynamicParams(new { @EditDateTime = item.EditDateTime });
                    parameters.AddDynamicParams(new { @IdOrder = item.IdOrder });
                    parameters.AddDynamicParams(new { @IdProduct = item.IdProduct });
                    parameters.AddDynamicParams(new { @IdUserCreate = item.IdUserCreate });
                    parameters.AddDynamicParams(new { @IdUserEdit = item.IdUserEdit });
                    parameters.AddDynamicParams(new { @ProductPrice = item.ProductPrice });
                    parameters.AddDynamicParams(new { @Qty = item.Qty });

                    await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "oit_OrderItemAdd");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
            return null;
        }
    }
}