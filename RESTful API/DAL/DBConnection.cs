using System.Data;
using Microsoft.Data.SqlClient;

namespace RESTful_API.DAL
{
    public class DBConnection
    {
        private static DBConnection? _instance;
        private readonly string _connectionString;
        private IDbConnection? _connection;

        private DBConnection() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path to the root directory of your project.
                .AddJsonFile("Secrets.json", optional: true, reloadOnChange: true); // Load secrets.json

            IConfigurationRoot configuration = builder.Build();
            _connectionString = GetConnectionString(configuration);
            _connection = new SqlConnection(_connectionString);
        }

        public static DBConnection Instance()
        {
            return _instance ??= new DBConnection();
        }

        private string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("ConnectionStrings:DbConnection")!;
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
            _instance = null;
        }
    }
}
