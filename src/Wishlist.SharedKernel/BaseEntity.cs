using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wishlist.SharedKernel; 

public abstract class BaseEntity {
    public virtual long Id { get; set; }

    private List<DomainEventBase> _domainEvents = new ();
    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
    
    internal void ClearDomainEvents() => _domainEvents.Clear();
}