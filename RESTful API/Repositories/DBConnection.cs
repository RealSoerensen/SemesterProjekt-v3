namespace RESTful_API.Repositories;

public static class DBConnection
{
    public static string GetConnectionString()
    {
        var configurationBuilder = new ConfigurationBuilder();
        IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
        var connectionString = configuration.GetSection("ConnectionStrings")["DbConnection"];
        return connectionString ?? throw new Exception("Connection string not found");
    }
}