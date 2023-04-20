using System.Data;

namespace WL.Application.Common.Interfaces;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
    Task<int> ExecuteAsync(string sql, params object[] param);
    IDbTransaction BeginTransaction();
}