using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPlayground.Menu;

/// <summary>
/// Collects and exposes the set of modules available to the application.
/// Use <see cref="Register"/> per module and call <see cref="Build"/> to get a read-only list.
/// </summary>
public sealed class ModuleRegistry
{
    private readonly List<IModule> _modules = new();

    /// <summary>
    /// Registers a module to the module registry.
    /// </summary>
    /// <param name="module">The module to be added to the registry. Cannot be null.</param>
    /// <returns>The current instance of <see cref="ModuleRegistry"/>, allowing for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="module"/> parameter is null.</exception>
    public ModuleRegistry Register(IModule module)
    {
        ArgumentNullException.ThrowIfNull(module);
        _modules.Add(module);
        return this;
    }

    /// <summary>
    /// Registers a range of modules to the module registry.
    /// </summary>
    /// <param name="modules">The collection of modules to be added to the registry. Cannot be null.</param>
    /// <returns>The current instance of <see cref="ModuleRegistry"/>, allowing for method chaining.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="modules"/> parameter is null.</exception>
    public ModuleRegistry RegisterRange(IEnumerable<IModule> modules)
    {
        if (modules == null)
            throw new ArgumentNullException(nameof(modules));
        _modules.AddRange(modules.Where(m => m is not null)!);
        return this;
    }

    /// <summary>
    /// Finalizes the module registry and provides a read-only list of registered modules.
    /// </summary>
    /// <returns>A read-only list of registered modules.</returns>
    public IReadOnlyList<IModule> Build() => _modules.AsReadOnly();
}