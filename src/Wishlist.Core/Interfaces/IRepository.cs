using Ardalis.Specification;

namespace Wishlist.Core.Interfaces; 

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
