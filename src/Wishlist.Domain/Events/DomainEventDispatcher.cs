using MediatR;
using Wishlist.Domain.Common;

namespace Wishlist.Domain.Events;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator) => _mediator = mediator;

    public async Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents)
    {
        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}