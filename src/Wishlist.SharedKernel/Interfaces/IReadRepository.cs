using Ardalis.Specification;

namespace Wishlist.SharedKernel.Interfaces; 

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
