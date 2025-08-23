using System.Threading;
using System.Threading.Tasks;

namespace CSharpPlayground.Menu;

/// <summary>
/// Interface for all modules that can ve launched from the menu.
/// The actual logic should live in separate services.
/// </summary>
public interface IModule
{
    /// <summary> Name of the module </summary>
    string Name { get; }
    
    /// <summary> Description of the module </summary>
    string Description { get; }

    /// <summary> Entry point of the module. Support cancellation through the provided token </summary>
    Task RunAsync(CancellationToken cancellationToken);
}