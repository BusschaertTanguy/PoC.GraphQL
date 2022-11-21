namespace Products.Domain.ValueObjects;

public record ReviewDescription
{
    public ReviewDescription(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(ReviewDescription));
        }

        Value = value;
    }

    public string Value { get; }
}