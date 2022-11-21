using Common.Domain.ValueObjects;

namespace Common.Domain.Entities;

public abstract class RootEntity : Entity
{
    protected RootEntity(EntityId id) : base(id)
    {
    }
}