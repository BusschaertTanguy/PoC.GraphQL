namespace Products.Domain.Mementos;

public sealed class ReviewMemento
{
    public required Guid Id { get; init; }
    public required string Description { get; init; }
    public required ProductMemento Product { get; init; }
}