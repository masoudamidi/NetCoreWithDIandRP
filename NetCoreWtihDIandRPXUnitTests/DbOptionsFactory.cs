using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RoamlerXUnitTests;
public static class DbOptionsFactory
{
    static DbOptionsFactory()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionString = config["ConnectionStrings:DefaultConnectionString"];

        DbContextOptions = new DbContextOptionsBuilder<NetCoreWithDIandRPContext>()
            .UseSqlServer(connectionString)
            .Options;
    }

    public static DbContextOptions<NetCoreWithDIandRPContext> DbContextOptions { get; }

}