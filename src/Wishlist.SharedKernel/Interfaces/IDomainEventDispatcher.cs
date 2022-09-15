namespace Wishlist.SharedKernel.Interfaces; 

public interface IDomainEventDispatcher {
    Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}