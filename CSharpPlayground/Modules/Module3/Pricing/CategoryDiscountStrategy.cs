using System;

namespace CSharpPlayground.Modules.Module3.Pricing;

/// <summary>
/// Applies a discount based on product category
/// </summary>
public sealed class CategoryDiscountStrategy : IPricingStrategy
{
    public string Name => "Category-based";

    public decimal CalculateLineTotal(decimal unitPrice, int quantity)
    {
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        var gross = unitPrice * quantity;

        // Example logic – later this can be moved to config or dictionary
        decimal discount = 0m;
        // NOTE: In real case we'd receive a Product object with Category.
        // For now, this method will assume unitPrice encodes category externally.

        // Placeholder: no actual category parameter here yet.
        // Will be refactored once we introduce Product.Category.
            
        return decimal.Round(gross * (1 - discount), 2, MidpointRounding.AwayFromZero);
    }
}