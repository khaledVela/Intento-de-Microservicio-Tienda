using System;

namespace Restaurant.SharedKernel.Core;

public abstract record DomainEvent 
{
    public DateTime OccuredOn { get; }
    public Guid Id { get; }    


    protected DomainEvent(DateTime occuredOn)
    {
        OccuredOn = occuredOn;
        Id = Guid.NewGuid();
    }
}
