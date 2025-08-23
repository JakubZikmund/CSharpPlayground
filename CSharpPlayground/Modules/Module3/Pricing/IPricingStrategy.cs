namespace CSharpPlayground.Modules.Module3.Pricing;

/// <summary>
/// Interface for pricing strategies (e.g., flat discount, category discount).
/// Implementations should be pure and side-effect free.
/// </summary>
public interface IPricingStrategy
{
    /// <summary>
    /// Human-readable strategy name (used in logs/UI)
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Calculates the final line total for a product given unit price and quantity.
    /// Arguments are expected to be non-negative; implementations should validate inputs.
    /// </summary>
    /// <param name="unitPrice">Price per unit (>= 0)</param>
    /// <param name="quantity">Units to purchase (>= 0)</param>
    /// <returns>Total price after applying the strategy (never negative)</returns>
    decimal CalculateLineTotal(decimal unitPrice, int quantity);
}