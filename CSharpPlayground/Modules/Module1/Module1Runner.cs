using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Menu;

namespace CSharpPlayground.Modules.Module1;

/// <summary>
/// Minimal module used to verify the menu.
/// Demonstrates async flow and cancellation support.
/// </summary>
public sealed class Module1Runner : IModule
{
    public string Name => "Hello Async World";
    public string Description => "Prints a greeting and simulates brief async work.";

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Hello from C# Playground!");
        Console.WriteLine("Simulating async work (press Ctrl+C to request cancellation)");

        for (int i = 1; i <= 3; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine($"Step {i}/3..");
            await Task.Delay(700, cancellationToken);
        }
        
        Console.WriteLine("Done.");
    }
}