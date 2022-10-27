using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace Wishlist.Infrastructure.Database;

public class ConnectionFactoryPostgreSQL : IConnectionFactory
{
    private readonly string _connectionString;

    public ConnectionFactoryPostgreSQL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection Create()
    {
        return Create(_connectionString);
    }

    public IDbConnection Create(string connectionString)
    {
        NpgsqlConnection dbConnection = new NpgsqlConnection(connectionString);
        dbConnection.Open();
        return dbConnection;
    }

    public async Task<IDbConnection> CreateAsync()
    {
        return await CreateAsync(_connectionString);
    }

    public async Task<IDbConnection> CreateAsync(string connectionString)
    {
        NpgsqlConnection dbConnection = new NpgsqlConnection(connectionString);
        await dbConnection.OpenAsync();
        return dbConnection;
    }
}