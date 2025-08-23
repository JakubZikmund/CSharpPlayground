using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpPlayground.Menu;
using CSharpPlayground.Modules.Module1;

namespace CSharpPlayground.App;

public class App
{
    public async Task RunAsync(string[] args)
    {
        // TODO: later we will pass a CancellationToken from outside (E.g. Ctrl+C handler)
        // using var zaručuje, že až Task používající tenhle token skončí, automaticky se zavolá Dispose()
        using var cts = new CancellationTokenSource();

        var registry = new ModuleRegistry()
            .Register(new HelloAsyncWorldModule())
            //.Register(new Module2())
            ;

        var menu = new MenuLoop(registry.Build());
        await menu.RunAsync(cts.Token);
    }
}    


