using System;
using CSharpPlayground.Domain;
using CSharpPlayground.Modules.Module3.Pricing;

namespace CSharpPlayground.Modules.Module3.Orders;

/// <summary>
/// Represents a single order line: product + quantity.
/// Pricing is calculated via a provided IPricingStrategy.
/// </summary>
public sealed class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }
    
    public OrderItem(Product product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive.");
        Quantity = quantity;
    }
    
    /// <summary>
    /// Calculates the line total using the given pricing strategy.
    /// The strategy is required to keep this class free of pricing rules.
    /// </summary>
    public decimal CalculateTotal(IPricingStrategy pricing)
    {
        if (pricing is null) throw new ArgumentNullException(nameof(pricing));
        return pricing.CalculateLineTotal(Product.Price, Quantity);
    }
    
    public override string ToString()
        => $"{Quantity} × {Product.Name} @ {Product.Price:C} ({Product.Category})";
}