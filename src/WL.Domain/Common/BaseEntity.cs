using System.ComponentModel.DataAnnotations.Schema;
using WL.Domain.Events;

namespace WL.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    private readonly List<DomainEventBase> _domainEvents = new();

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);

    public void RemoveDomainEvent(DomainEventBase domainEvent) => _domainEvents.Remove(domainEvent);

    internal void ClearDomainEvents() => _domainEvents.Clear();
}