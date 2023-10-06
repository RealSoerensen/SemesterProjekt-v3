namespace RESTful_API.DAL;

public class DBConnection
{
    public string? ConnectionString { get; private set; }

    public DBConnection()
    {
        try
        {
            var configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
            ConnectionString = configuration.GetSection("ConnectionStrings")["DbConnection"];
        }
        catch (Exception e)
        {
            Console.WriteLine("Unable to get Connection String from secrets\n" + e.Message);
        }
    }
}