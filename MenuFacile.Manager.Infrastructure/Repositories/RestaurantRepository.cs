using Dapper;
using MenuFacile.Manager.Domain.Contracts.Repositories;
using MenuFacile.Manager.Domain.DTO.Request.Restaurant;
using MenuFacile.Manager.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public async Task<IEnumerable<T>> RestaurantAdd<T>(T response, RestaurantAddRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Description = request.Description });
                parameters.AddDynamicParams(new { @FreeDelivery = request.FreeDelivery });
                parameters.AddDynamicParams(new { @CreateDateTime = request.CreateDateTime });
                parameters.AddDynamicParams(new { @MinimumDeliveryValue = request.MinimumDeliveryValue });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @Address = request.Address });
                parameters.AddDynamicParams(new { @AddressNumber = request.AddressNumber });
                parameters.AddDynamicParams(new { @Cnpj = request.Cnpj });
                parameters.AddDynamicParams(new { @Complement = request.Complement });
                parameters.AddDynamicParams(new { @CreateDateTime = request.CreateDateTime });
                parameters.AddDynamicParams(new { @DaysOperation = request.DaysOperation });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @EndHoursOperation = request.EndHoursOperation });
                parameters.AddDynamicParams(new { @IdCity = request.IdCity });
                parameters.AddDynamicParams(new { @IdSegment = request.IdSegment });
                parameters.AddDynamicParams(new { @IdState = request.IdState });
                parameters.AddDynamicParams(new { @IdUserCreate = request.IdUserCreate });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
                parameters.AddDynamicParams(new { @ImageLogo = request.ImageLogo });
                parameters.AddDynamicParams(new { @MinimumDeliveryValue = request.MinimumDeliveryValue });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Neighborhood = request.Neighborhood });
                parameters.AddDynamicParams(new { @OpenFriday = request.OpenFriday });
                parameters.AddDynamicParams(new { @OpenMonday = request.OpenMonday });
                parameters.AddDynamicParams(new { @OpenSaturday = request.OpenSaturday });
                parameters.AddDynamicParams(new { @OpenSunday = request.OpenSunday });
                parameters.AddDynamicParams(new { @OpenThursday = request.OpenThursday });
                parameters.AddDynamicParams(new { @OpenTuesday = request.OpenTuesday });
                parameters.AddDynamicParams(new { @OpenWednesday = request.OpenWednesday });
                parameters.AddDynamicParams(new { @StartHoursOperation = request.StartHoursOperation });
                parameters.AddDynamicParams(new { @ZipCode = request.ZipCode });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
                        
            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "res_RestaurantAdd");
        }

        public async Task<IEnumerable<T>> RestaurantList<T>(T response)
        {
            try
            {
                return await new DapperSqlServerConfig().GetListByProcedure<T>(response, null, "res_RestaurantList");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<T>> RestaurantEdit<T>(T response, RestaurantEditRequest request)
        {
            DynamicParameters parameters = new DynamicParameters();

            try
            {
                parameters.AddDynamicParams(new { @IdRestaurant = request.IdRestaurant });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Description = request.Description });
                parameters.AddDynamicParams(new { @FreeDelivery = request.FreeDelivery });
                parameters.AddDynamicParams(new { @MinimumDeliveryValue = request.MinimumDeliveryValue });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @Active = request.Active });
                parameters.AddDynamicParams(new { @Address = request.Address });
                parameters.AddDynamicParams(new { @AddressNumber = request.AddressNumber });
                parameters.AddDynamicParams(new { @Cnpj = request.Cnpj });
                parameters.AddDynamicParams(new { @Complement = request.Complement });
                parameters.AddDynamicParams(new { @DaysOperation = request.DaysOperation });
                parameters.AddDynamicParams(new { @EditDateTime = request.EditDateTime });
                parameters.AddDynamicParams(new { @EndHoursOperation = request.EndHoursOperation });
                parameters.AddDynamicParams(new { @IdCity = request.IdCity });
                parameters.AddDynamicParams(new { @IdSegment = request.IdSegment });
                parameters.AddDynamicParams(new { @IdState = request.IdState });
                parameters.AddDynamicParams(new { @IdUserEdit = request.IdUserEdit });
                parameters.AddDynamicParams(new { @ImageLogo = request.ImageLogo });
                parameters.AddDynamicParams(new { @MinimumDeliveryValue = request.MinimumDeliveryValue });
                parameters.AddDynamicParams(new { @Name = request.Name });
                parameters.AddDynamicParams(new { @Neighborhood = request.Neighborhood });
                parameters.AddDynamicParams(new { @OpenFriday = request.OpenFriday });
                parameters.AddDynamicParams(new { @OpenMonday = request.OpenMonday });
                parameters.AddDynamicParams(new { @OpenSaturday = request.OpenSaturday });
                parameters.AddDynamicParams(new { @OpenSunday = request.OpenSunday });
                parameters.AddDynamicParams(new { @OpenThursday = request.OpenThursday });
                parameters.AddDynamicParams(new { @OpenTuesday = request.OpenTuesday });
                parameters.AddDynamicParams(new { @OpenWednesday = request.OpenWednesday });
                parameters.AddDynamicParams(new { @StartHoursOperation = request.StartHoursOperation });
                parameters.AddDynamicParams(new { @ZipCode = request.ZipCode });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "res_RestaurantEdit");
        }

        public async Task<IEnumerable<T>> RestaurantDelete<T>(T response, RestaurantBaseRequest request)
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

            return await new DapperSqlServerConfig().ExecuteProcedure<T>(response, parameters, "res_RestaurantDelete");
        }

        public async Task<T> GetRestaurantByIdAsync<T>(T response, RestaurantBaseRequest request)
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

            return await new DapperSqlServerConfig().GetByIdByProcedure<T>(response, parameters, "res_GetRestaurantById");
        }
    }
}
