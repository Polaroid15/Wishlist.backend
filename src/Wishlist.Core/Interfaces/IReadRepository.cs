using Ardalis.Specification;

namespace Wishlist.Core.Interfaces; 

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
