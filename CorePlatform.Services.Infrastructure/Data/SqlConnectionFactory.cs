using CorePlatform.Services.UseCases.Abstraction.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CorePlatform.Services.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var con = new SqlConnection(_connectionString);
            con.Open();

            return con;
        }
    }
}
