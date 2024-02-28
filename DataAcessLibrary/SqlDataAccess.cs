using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        private readonly string? connectionString;

        public string ConnectionStringName { get; set; } = "Default";


        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString(ConnectionStringName);
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameter);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameter);
            }
        }
    }


}
