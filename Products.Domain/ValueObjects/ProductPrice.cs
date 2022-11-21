namespace Products.Domain.ValueObjects;

public sealed record ProductPrice
{
    public ProductPrice(decimal value)
    {
        if (value <= 0)
        {
            throw new InvalidOperationException("Price should be above 0");
        }

        Value = value;
    }

    public decimal Value { get; }
}