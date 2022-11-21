using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Products.Domain.Mementos;
using Products.Domain.ValueObjects;

namespace Products.Domain.Entities;

public class Review : RootEntity
{
    public Review(EntityId id, EntityId productId, ReviewDescription description) : base(id)
    {
        ProductId = productId;
        Description = description;
    }

    internal ReviewDescription Description { get; }
    internal EntityId ProductId { get; }

    internal static Review FromMemento(ReviewMemento memento)
    {
        return new
        (
            new(memento.Id),
            new(memento.Product.Id),
            new(memento.Description)
        );
    }
}