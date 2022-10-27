using Ardalis.Specification;

namespace Wishlist.SharedKernel.Interfaces;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}