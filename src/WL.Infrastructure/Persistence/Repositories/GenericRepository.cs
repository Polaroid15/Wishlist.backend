using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WL.Application.Common.Interfaces;

namespace WL.Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
{
    protected readonly AppDbContext DbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await DbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size)
    {
        return await DbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public Task<int> ExecuteAsync(string sql, params object[] param) => DbContext.Database.ExecuteSqlRawAsync(sql, param);

    public IDbTransaction BeginTransaction()
    {
        var transaction = DbContext.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}