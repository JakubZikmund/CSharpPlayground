using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Domain;
using CSharpPlayground.Menu;
using CSharpPlayground.Modules.Module3.Inventory;
using CSharpPlayground.Modules.Module3.Orders;
using CSharpPlayground.Modules.Module3.Pricing;

namespace CSharpPlayground.Modules.Module3;

/// <summary>
/// Demonstrates OOP and SOLID principles with products, orders,
/// pricing strategies and inventory management.
/// </summary>
public sealed class Module3Runner : IModule
{
    public string Name => "OOP & SOLID";
    public string Description => "Showcases products, orders, pricing strategies, and inventory service.";

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Module 3: OOP & SOLID");
        Console.WriteLine("----------------------");

        // Sample product
        var laptop = new Product("Laptop", 1500m, "Electronics");

        // Set up inventory with stock
        var inventory = new InMemoryInventoryService(new[]
        {
            (laptop, 5) // 5 laptops in stock
        });

        // Choose pricing strategy
        IPricingStrategy pricing = new FlatDiscountStrategy(0.10m); // 10% discount

        // Set up order service
        var orderService = new OrderService(pricing, inventory);

        // Try to create an order
        var order = orderService.CreateSingleItemOrder(laptop, 7);
        if (order is null)
        {
            Console.WriteLine("Order could not be created.");
            return;
        }

        // Calculate total
        var total = orderService.CalculateTotal(order);
        Console.WriteLine($"Order created: {order}");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"  {item}");
        }
        Console.WriteLine($"Total: {total:C}");

        await Task.CompletedTask;
    }

}