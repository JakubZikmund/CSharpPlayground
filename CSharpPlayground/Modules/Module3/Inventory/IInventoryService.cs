using CSharpPlayground.Domain;

namespace CSharpPlayground.Modules.Module3.Inventory;

/// <summary>
/// Abstraction for product inventory management.
/// Implementations may store state in memory, database, or external system.
/// </summary>
public interface IInventoryService
{
    /// <summary>
    /// Returns true if the given product has at least the requested quantity in stock.
    /// </summary>
    bool IsAvailable(Product product, int requestedQuantity);
    
    /// <summary>
    /// Attempts to reserve the given quantity of a product.
    /// Returns true if successful, false if insufficient stock.
    /// </summary>
    bool Reserve(Product product, int quantity);
    
    /// <summary>
    /// Releases a previously reserved quantity (e.g., if order was canceled).
    /// Implementations should be idempotent.
    /// </summary>
    void Release(Product product, int quantity);
}