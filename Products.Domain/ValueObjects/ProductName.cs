namespace Products.Domain.ValueObjects;

public sealed record ProductName
{
    public ProductName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(ProductName));
        }

        Value = value;
    }

    public string Value { get; }
}