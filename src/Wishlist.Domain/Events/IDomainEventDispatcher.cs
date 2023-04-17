using Wishlist.Domain.Common;

namespace Wishlist.Domain.Events;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}