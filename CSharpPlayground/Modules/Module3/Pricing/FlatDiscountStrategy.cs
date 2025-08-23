using System;

namespace CSharpPlayground.Modules.Module3.Pricing;

/// <summary>
/// Applies a flat percentage discount to the line total.
/// Example: 10% discount → unitPrice * quantity * (1-0.10).
/// </summary>
public sealed class FlatDiscountStrategy : IPricingStrategy
{
    /// <summary>
    /// Discount factor in range (0,1)
    /// </summary>
    public decimal Discount { get; }
    public string Name => $"Flat {Discount:P0}%";
    
    public FlatDiscountStrategy(decimal discount)
    {
        // m značí decimal
        if (discount is < 0m or > 1m)
            throw new ArgumentOutOfRangeException(nameof(discount), "Discount must be in range (0,1)");
        Discount = discount;
    }

    public decimal CalculateLineTotal(decimal unitPrice, int quantity)
    {
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative");
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative");

        var gross = unitPrice * quantity;
        var net = gross * (1 - Discount);

        return net < 0 ? 0 : decimal.Round(net, 2, MidpointRounding.AwayFromZero);
    }
}
