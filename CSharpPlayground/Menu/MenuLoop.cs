using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpPlayground.Menu;

/// <summary>
/// Simple console-driven loop that lists modules and runs selected one.
/// Provide a list of IModule instances in the constructor.
/// </summary>
public sealed class MenuLoop
{
    private readonly IReadOnlyList<IModule> _modules;

    public MenuLoop(IEnumerable<IModule> modules)
    {
        _modules = modules?.ToList().AsReadOnly()
                   ?? throw new ArgumentNullException(nameof(modules));
    }

    /// <summary>
    /// Starts the interactive menu. Supports cancellation via the provided token.
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Clear();
            PrintHeader();
            PrintModules();
            
            Console.Write("\nSelect module (number), 'h' for help, 'q' to quit: ");
            var input = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

            if (input == "q") break;

            if (input == "h")
            {
                ShowHelp();
                WaitForEnter();
                continue;
            }

            if (int.TryParse(input, out var num))
            {
                var index = num - 1;
                if (index >= 0 && index < _modules.Count)
                {
                    var module = _modules[index];
                    Console.Clear();
                    Console.WriteLine($">>> Running module: {module.Name}\n");

                    try
                    {
                        await module.RunAsync(cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("\nOperation cancelled.");;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nAn error occured: {e.Message}");
                    }
                    
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    continue;
                }
            }

            Console.WriteLine("Invalid choice :(");
            Console.WriteLine("Press Enter to try again...");
            Console.ReadLine();
        }
    }
    
    private static void PrintHeader()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("         C# Playground - Menu        ");
        Console.WriteLine("========================================");
    }

    private void PrintModules()
    {
        if (_modules.Count == 0)
        {
            Console.WriteLine("No modules available");
            return;
        }

        for (int i = 0; i < _modules.Count; i++)
        {
            Console.WriteLine($"{i + 1}. { _modules[i].Name}");
        }
    }

    private void ShowHelp()
    {
        Console.WriteLine("\nAvailable modules:");
        if (_modules.Count == 0)
        {
            Console.WriteLine("  (none)");
            return;
        }

        for (int i = 0; i < _modules.Count; i++)
        {
            var m = _modules[i];
            Console.WriteLine($"  {i + 1}. {m.Name} - {m.Description}");
        }
    }
    
    private static void WaitForEnter()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}