using Dapper;
using MenuFacile.Manager.Infrastructure.Configuration;
using MenuFacile.Order.Domain.Contracts.Repositories;
using MenuFacile.Order.Domain.DTO.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Order.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        public async Task<IEnumerable<T>> GetListCurrentProductsByIdRestaurantAsync<T>(T response, GetListCurrentProductsByIdRestaurantRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @ValidFrom = request.ValidFrom });
                parameters.AddDynamicParams(new { @ValidUntil = request.ValidUntil });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetListByProcedure<T>(response, parameters, "ord_GetListCurrentProductsByIdRestaurant");
        }

        public async Task<T> GetOrderRestaurantAsync<T>(T response, OrderBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "ord_GetOrderRestaurant");
        }

        public async Task<IEnumerable<T>> GetPaymentMethodsByIdRestaurantAsync<T>(T response, OrderBaseRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetListByProcedure<T>(response, parameters, "ord_GetPaymentMethodsByIdRestaurant");
        }

        public async Task<IEnumerable<T>> OrderAdd<T>(T response, OrderAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @ChangeFor = request.ChangeFor });
                parameters.AddDynamicParams(new { @CreateDateTime = request.CreateDateTime });
                parameters.AddDynamicParams(new { @CustomerAddress = request.CustomerAddress });
                parameters.AddDynamicParams(new { @CustomerName = request.CustomerName });
                parameters.AddDynamicParams(new { @CustomerPhone = request.CustomerPhone });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdPaymentMethod = request.IdPaymentMethod });
                parameters.AddDynamicParams(new { @IdUserCreate = request.IdUserCreate });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
                parameters.AddDynamicParams(new { @LinkOrder = request.LinkOrder });
                parameters.AddDynamicParams(new { @Status = request.Status });
                parameters.AddDynamicParams(new { @TotalOrder = request.TotalOrder });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ord_OrderAdd");
        }

        public async Task<IEnumerable<T>> OrderEdit<T>(T response, OrderEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdOrder = request.IdOrder });
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @ChangeFor = request.ChangeFor });
                parameters.AddDynamicParams(new { @CustomerAddress = request.CustomerAddress });
                parameters.AddDynamicParams(new { @CustomerName = request.CustomerName });
                parameters.AddDynamicParams(new { @CustomerPhone = request.CustomerPhone });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @IdPaymentMethod = request.IdPaymentMethod });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
                parameters.AddDynamicParams(new { @LinkOrder = request.LinkOrder });
                parameters.AddDynamicParams(new { @Status = request.Status });
                parameters.AddDynamicParams(new { @TotalOrder = request.TotalOrder });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ord_OrderEdit");
        }

        public async Task<IEnumerable<T>> GetOrderListAsync<T>(T response, GetOrderListRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @DateFrom = request.DateFrom });
                parameters.AddDynamicParams(new { @DateTo = request.DateTo });
                parameters.AddDynamicParams(new { @OrderStatus = request.OrderStatus });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetListByProcedure<T>(response, parameters, "ord_GetOrderList");
        }

        public async Task<IEnumerable<T>> OrderUpdateStatusAsync<T>(T response, OrderUpdateStatusRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdOrder = request.IdOrder });
                parameters.AddDynamicParams(new { @OrderStatus = request.OrderStatus });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "ord_OrderUpdateStatus");
        }

        public async Task<IEnumerable<T>> GetOrderDetailAsync<T>(T response, GetOrderDetailRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdOrder = request.IdOrder });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().GetListByProcedure<T>(response, parameters, "ord_GetOrderDetail");
        }
    }
}