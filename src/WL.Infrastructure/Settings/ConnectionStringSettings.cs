using Microsoft.Extensions.Configuration;
using WL.Application.Common.Interfaces;

namespace WL.Infrastructure.Settings;

public class ConnectionStringSettings : IConnectionStringSettings
{
    public ConnectionStringSettings(IConfiguration configuration)
    {
        PostgresDb = configuration.GetConnectionString("WishesDb");
        RedisDb = configuration.GetConnectionString("Redis");
    }

    public string PostgresDb { get; }

    public string RedisDb { get; set; }
}