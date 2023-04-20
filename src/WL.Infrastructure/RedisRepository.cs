using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using WL.Infrastructure.Persistence;

namespace WL.Infrastructure;

public class RedisRepository : IRedisRepository 
{
    private readonly IConnectionMultiplexer _connection;

    public RedisRepository(IConnectionMultiplexer connection) 
    {
        _connection = connection;
    }

    public async Task<T> GetAsync<T>(string key) 
    {
        IDatabase database = _connection.GetDatabase();
        var value = await database.StringGetAsync(key);
        return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public async Task<List<T>> GetListAsync<T>(string[] keys) 
    {
        IDatabase database = _connection.GetDatabase();
        var redisKeys = keys.Select(x => new RedisKey(x)).ToArray();
        var values = await database.StringGetAsync(redisKeys);
        var result = new List<T>();
        if (values.Any(x => x.HasValue)) 
        {
            result = values.Select(value => JsonSerializer.Deserialize<T>(value)).ToList();
        }

        return result;
    }

    public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null) 
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentNullException(nameof(key));

        var strValue = ToStringValue(value);

        IDatabase database = _connection.GetDatabase();
        return await database.StringSetAsync(key, strValue, expiry);
    }

    public async Task<bool> SetBatchAsync<T>(Dictionary<string, T> keyValuePairs) 
    {
        var database = _connection.GetDatabase();
        var insertList = keyValuePairs
            .Select(x => new KeyValuePair<RedisKey, RedisValue>(x.Key, ToStringValue(x.Value)))
            .ToArray();
        
        var result = await database.StringSetAsync(insertList);
        return result;
    }

    public async Task<bool> ExpireAsync(string key, TimeSpan? expiry) 
    {
        IDatabase database = _connection.GetDatabase();
        return await database.KeyExpireAsync(key, expiry);
    }

    public async Task<bool> DeleteAsync(string key) 
    {
        IDatabase database = _connection.GetDatabase();
        return await database.KeyDeleteAsync(key);
    }

    private static string ToStringValue<T>(T value) 
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        string strValue = value switch 
        {
            IConvertible convertible => convertible.ToString(CultureInfo.InvariantCulture),
            Guid id => id.ToString(),
            _ => JsonSerializer.Serialize(value)
        };
        return strValue;
    }
}