namespace CSharpPlayground.Domain;

/// <summary>
/// Represents a simple product with a name and price.
/// Immutable record, easy to use with LINQ
/// </summary>
public record Product(string Name, decimal Price, string Category);