using System.Data.SqlClient;
using Dapper;
using ModularisTest.Interfaces;

namespace ModularisTest.DataAccess
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        public DbContext(ISettings settings)
        {
            _connectionString = settings.GetValue("ConnectionString");
        }
        
        public void RunQuery(string query, object parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                 _ = connection.Execute(query, parameters);
            }
        }
        
    }
}