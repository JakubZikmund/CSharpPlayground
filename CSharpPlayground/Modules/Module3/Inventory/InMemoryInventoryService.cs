using System;
using System.Collections.Generic;
using CSharpPlayground.Domain;

namespace CSharpPlayground.Modules.Module3.Inventory;

/// <summary>
/// In-memory inventory storage based on a dictionary.
/// Suitable for demos and testing. Not thread-safe.
/// </summary>
public sealed class InMemoryInventoryService : IInventoryService
{
    private readonly Dictionary<Product, int> _stock = new();
    
    /// <summary>
    /// Initializes the inventory with an optional seed of product quantities.
    /// </summary>
    public InMemoryInventoryService(IEnumerable<(Product product, int quantity)>? seed = null)
    {
        if (seed != null)
        {
            foreach (var (product, quantity) in seed)
            {
                if (quantity < 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be non-negative.");
                _stock[product] = quantity;
            }
        }
    }
    
    public bool IsAvailable(Product product, int requestedQuantity)
    {
        if (requestedQuantity <= 0) throw new ArgumentOutOfRangeException(nameof(requestedQuantity), "Requested quantity must be at least 1.");;
        return _stock.TryGetValue(product, out var available) && available >= requestedQuantity;
    }
    
    public bool Reserve(Product product, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
        // TryGetValue vrací bool, ale taky pomocí out vytvoří proměnnou var - 
        if (!_stock.TryGetValue(product, out var available) || available < quantity)
            return false;

        _stock[product] = available - quantity;
        return true;
    }
    
    public void Release(Product product, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
        if (_stock.TryGetValue(product, out var available))
        {
            _stock[product] = available + quantity;
        }
        else
        {
            _stock[product] = quantity;
        }
    }
    
}