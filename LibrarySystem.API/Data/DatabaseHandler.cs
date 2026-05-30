using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LibrarySystem.API.Data
{
    public class DatabaseHandler
    {
        private readonly string _connectionString;

        public DatabaseHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetNewConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}}
