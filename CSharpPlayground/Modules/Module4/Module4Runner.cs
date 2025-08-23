using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Menu;

namespace CSharpPlayground.Modules.Module4;

/// <summary>
/// Demonstrates async I/O: reading and writing files, JSON processing,
/// and cancellation-aware asynchronous tasks.
/// </summary>
public sealed class Module4Runner : IModule
{
    public string Name => "Async I/O";
    public string Description => "Shows async file and JSON operations with cancellation support.";
    
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Module 4: Async I/O");
        Console.WriteLine("-------------------");

        // Example: write some JSON to a file asynchronously
        var sampleData = new { Message = "Hello from async I/O", Time = DateTime.UtcNow };

        var filePath = "exports\\sample.json";
        Console.WriteLine($"Writing to {Path.GetFullPath(filePath)}");
        await using (var stream = File.Create(filePath))
        {
            await JsonSerializer.SerializeAsync(stream, sampleData, cancellationToken: cancellationToken);
        }

        Console.WriteLine($"Data written to {filePath}");
        
        // Example: read JSON back asynchronously
        await using (var stream = File.OpenRead(filePath))
        {
            var data = await JsonSerializer.DeserializeAsync<object>(stream, cancellationToken: cancellationToken);
            Console.WriteLine("Read back:");
            Console.WriteLine(JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}