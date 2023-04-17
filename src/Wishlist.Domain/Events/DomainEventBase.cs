using MediatR;

namespace Wishlist.Domain.Events; 

public abstract record DomainEventBase : INotification 
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
}