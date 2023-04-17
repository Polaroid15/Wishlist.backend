using Microsoft.Extensions.Configuration;
using Wishlist.Application.Common.Interfaces;

namespace Wishlist.Infrastructure.Settings;

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