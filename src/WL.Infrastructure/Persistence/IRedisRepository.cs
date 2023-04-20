using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WL.Infrastructure.Persistence;

public interface IRedisRepository {
    Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
    Task<bool> SetBatchAsync<T>(Dictionary<string, T> keyValuePairs);
    Task<T> GetAsync<T>(string key);
    Task<List<T>> GetListAsync<T>(string[] keys);
    Task<bool> ExpireAsync(string key, TimeSpan? expiry);
    Task<bool> DeleteAsync(string key);
}