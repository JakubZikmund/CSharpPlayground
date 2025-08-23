using System;
using CSharpPlayground.Domain;
using CSharpPlayground.Modules.Module3.Inventory;
using CSharpPlayground.Modules.Module3.Pricing;

namespace CSharpPlayground.Modules.Module3.Orders;

/// <summary>
/// Coordinates order creation: checks inventory, reserves stock,
/// and returns an Order instance with items.
/// </summary>
public sealed class OrderService
{
    private readonly IPricingStrategy _pricing;
    private readonly IInventoryService _inventory;
    
    public OrderService(IPricingStrategy pricing, IInventoryService inventory)
    {
        _pricing = pricing ?? throw new ArgumentNullException(nameof(pricing));
        _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
    }
    
    /// <summary>
    /// Attempts to create an order with one product and quantity.
    /// Returns the created order if successful, null if stock was insufficient.
    /// </summary>
    public Order? CreateSingleItemOrder(Product product, int quantity)
    {
        try
        {
            if (!_inventory.IsAvailable(product, quantity))
                return null;
            if (!_inventory.Reserve(product, quantity))
                return null;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
        

        var order = new Order();
        order.AddItem(new OrderItem(product, quantity));
        return order;
    }
    
    /// <summary>
    /// Calculates the total for the given order using the injected pricing strategy.
    /// </summary>
    public decimal CalculateTotal(Order order)
    {
        if (order is null) throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        return order.CalculateTotal(_pricing);
    }
}