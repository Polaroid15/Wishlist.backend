using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wishlist.SharedKernel.Interfaces;

namespace Wishlist.Infrastructure; 

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot {
    public EfRepository(DbContext dbContext) : base(dbContext) { }
}