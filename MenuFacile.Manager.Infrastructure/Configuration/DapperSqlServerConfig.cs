using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MenuFacile.Manager.Infrastructure.Configuration
{
    public class DapperSqlServerConfig
    {
        public async Task<string> ExecuteProcedure(DynamicParameters parameters, string procedureName)
        {
            using (var connection = new SqlConnection(SqlServerConnectionString()))
            {
                var jsonReturn = await connection.QueryAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return JsonConvert.SerializeObject(jsonReturn);
            }
        }

        public async Task<IEnumerable<T>> ExecuteProcedure<T>(T response, DynamicParameters parameters, string procedureName)
        {
            using (var connection = new SqlConnection(SqlServerConnectionString()))
            {
                var jsonReturn = await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return jsonReturn;
            }
        }

        public async Task<T> GetByIdByProcedure<T>(T response, DynamicParameters parameters, string procedureName)
        {
            using (var connection = new SqlConnection(SqlServerConnectionString()))
            {
                var jsonReturn = await connection.QueryFirstAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return (T)jsonReturn;
            }
        }

        public async Task<IEnumerable<T>> GetListByProcedure<T>(T response, DynamicParameters parameters, string procedureName)
        {
            using (var connection = new SqlConnection(SqlServerConnectionString()))
            {
                var jsonReturn = await connection.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return jsonReturn;
            }
        }

        public string SqlServerConnectionString()
        {
            string c = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();
            string connectionStringIs = configuration.GetConnectionString("sqlServerConnectionString");

            return connectionStringIs;
        }
    }
}
