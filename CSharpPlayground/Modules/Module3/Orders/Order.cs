using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPlayground.Modules.Module3.Orders;

/// <summary>
/// Represents a customer order, consisting of multiple order items.
/// Immutable ID, collection of items, and timestamp.
/// </summary>
public sealed class Order
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    
    private readonly List<OrderItem> _items = new();

    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    
    public Order() { }
    
    /// <summary>
    /// Adds an item to the order.
    /// </summary>
    public void AddItem(OrderItem item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }
    
    /// <summary>
    /// Total line count (items).
    /// </summary>
    public int ItemCount => _items.Count;
    
    /// <summary>
    /// Calculates the order total using the provided pricing strategy.
    /// </summary>
    public decimal CalculateTotal(Pricing.IPricingStrategy pricing)
    {
        if (pricing is null) throw new ArgumentNullException(nameof(pricing), "Pricing strategy cannot be null.");
        return _items.Sum(i => i.CalculateTotal(pricing));
    }
    
    public override string ToString()
        => $"Order {Id}, {ItemCount} items, created {CreatedAt:u}";
}