namespace Common.Domain.ValueObjects;

public record EntityId
{
    public EntityId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(EntityId));
        }

        Value = value;
    }

    public Guid Value { get; }

    public static EntityId New()
    {
        return new(Guid.NewGuid());
    }
}