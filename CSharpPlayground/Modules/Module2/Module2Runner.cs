using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Domain;
using CSharpPlayground.Menu;

namespace CSharpPlayground.Modules.Module2;

/// <summary>
/// Demonstrates operations on collections using LINQ (Language Integrated Query):
/// search, filter, sort and aggregation.
/// </summary>
public sealed class Module2Runner : IModule
{
    public string Name => "Collections & LINQ";
    public string Description => "Showcase search, filter, sort and aggregation over data.";

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("----------------------------");

        // Sample dataset
        var products = GetSampleProducts();
        
        Console.WriteLine("All products:");
        foreach (var p in products)
        {
            Console.WriteLine($" - {p.Name} ({p.Price:C})");
        }
        
        Console.WriteLine("\n Products over 100:");
        var filtered = products.Where(p => p.Price > 100);
        foreach (var p in filtered)
        {
            Console.WriteLine($" - {p.Name} ({p.Price:C})");
        }
        
        Console.WriteLine("\nAverage price:");
        var avg = products.Average(p => p.Price);
        Console.WriteLine($" {avg:C}");

        await Task.CompletedTask;
    }

    private static List<Product> GetSampleProducts()
    {
        return new List<Product>
        {
            new Product("Book", 50, "Books"),
            new Product("Laptop", 1500, "Electronics"),
            new Product("Pencil", 10, "Office supplies"),
            new Product("Phone", 800, "Electronics"),
            new Product("Pen", 20, "Office supplies"),
        };
    }
}