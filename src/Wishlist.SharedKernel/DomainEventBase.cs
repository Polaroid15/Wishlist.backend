using System;
using MediatR;

namespace Wishlist.SharedKernel; 

public abstract class DomainEventBase : INotification 
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}