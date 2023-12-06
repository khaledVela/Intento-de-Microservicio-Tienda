namespace Restaurant.SharedKernel.Core;

public abstract class AggregateRoot : Entity
{
    private readonly ICollection<DomainEvent> _domainEvents;

    public ICollection<DomainEvent> DomainEvents => _domainEvents.ToList();

    protected AggregateRoot(Guid id) : base(id)
    {
        _domainEvents = new List<DomainEvent>();
    }

    protected AggregateRoot() : base()
    {
        _domainEvents = new List<DomainEvent>();
    }

    public void AddDomainEvent(DomainEvent @event)
    {
        _domainEvents.Add(@event);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
