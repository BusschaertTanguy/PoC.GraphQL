namespace Products.Domain.Mementos;

public sealed class ProductMemento
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required  ICollection<ReviewMemento> Reviews { get; init; }
}