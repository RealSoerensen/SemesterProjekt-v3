using Microsoft.Extensions.DependencyInjection;
using Models;
using RESTful_API.DAL;

var builder = WebApplication.CreateBuilder(args);

// Get connection string
var configurationBuilder = new ConfigurationBuilder();
IConfiguration configuration = configurationBuilder.AddUserSecrets<Program>().Build();
var connectionString = configuration.GetSection("ConnectionStrings")["DbConnection"];
if (connectionString == null)
{
    Console.WriteLine("Unable to get Connection String from secrets");
    return;
}

// Add services to the container.
builder.Services.AddScoped(_ => new CustomerDB(connectionString));
builder.Services.AddScoped(_ => new OrderDB(connectionString));
builder.Services.AddScoped(_ => new AddressDB(connectionString));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();