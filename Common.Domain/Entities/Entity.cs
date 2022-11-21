using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public abstract class Entity
{
    protected Entity(EntityId id)
    {
        Id = id;
    }

    public EntityId Id { get; }
}