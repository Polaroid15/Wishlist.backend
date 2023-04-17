namespace Wishlist.Application.Common.Interfaces;

public interface IConnectionStringSettings
{
    string PostgresDb { get; }
    string RedisDb { get; set; }
}