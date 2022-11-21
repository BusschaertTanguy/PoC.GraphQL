using Common.Domain.Entities;
using Common.Domain.ValueObjects;
using Products.Domain.Mementos;
using Products.Domain.ValueObjects;

namespace Products.Domain.Entities;

public sealed class Product : RootEntity
{
    public Product(EntityId id, ProductName name, ProductPrice price) : base(id)
    {
        Name = name;
        Price = price;
    }

    internal ProductName Name { get; }
    internal ProductPrice Price { get; }

    public Review CreateReview(ReviewDescription description)
    {
        return new(EntityId.New(), Id, description);
    }

    internal static Product FromMemento(ProductMemento memento)
    {
        return new
        (
            new(memento.Id),
            new(memento.Name),
            new(memento.Price)
        );
    }
}