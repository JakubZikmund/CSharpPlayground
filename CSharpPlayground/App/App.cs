using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Menu;
using CSharpPlayground.Modules.Module1;
using CSharpPlayground.Modules.Module2;
using CSharpPlayground.Modules.Module3;
using CSharpPlayground.Modules.Module4;

namespace CSharpPlayground.App;

public class App
{
    public async Task RunAsync(string[] args)
    {
        // TODO: later we will pass a CancellationToken from outside (E.g. Ctrl+C handler)
        // using var zaručuje, že až Task používající tenhle token skončí, automaticky se zavolá Dispose()
        using var cts = new CancellationTokenSource();

        // handle Ctrl+C -> cancel, dont kill the process
        ConsoleCancelEventHandler? handler = null;
        handler = (_, e) =>
        {
            e.Cancel = true;
            if (!cts.IsCancellationRequested)
                cts.Cancel();
        };
        Console.CancelKeyPress += handler;
        
        var registry = new ModuleRegistry()
            .Register(new Module1Runner())
            .Register(new Module2Runner())
            .Register(new Module3Runner())
            .Register(new Module4Runner())
            ;

        var menu = new MenuLoop(registry.Build());
        await menu.RunAsync(cts.Token);
    }
}    


