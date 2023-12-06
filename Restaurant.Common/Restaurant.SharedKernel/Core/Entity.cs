namespace Restaurant.SharedKernel.Core;

public abstract class Entity
{
    public Guid Id { get; protected set; }
       

    protected Entity()
    {       
        Id = Guid.NewGuid();
    }
    protected Entity(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("The id cannot be empty", nameof(id));
        }
        Id = id;        
    }

    public override bool Equals(object? obj)
    {
        if (!(obj is Entity))
        {
            return false;
        }
        if (Object.ReferenceEquals(this, obj))
        {
            return true;
        }
        if (this.GetType() != obj.GetType())
        {
            return false;
        }
        Entity item = (Entity)obj;
        return item.Id == this.Id;
    }

    protected void CheckRule(IBussinessRule rule)
    {
        if(rule is null)
        {
            throw new ArgumentException("Rule cannot be null");
        }
        if (!rule.IsValid())
        {
            throw new BussinessRuleValidationException(rule);
        }
    }
}
