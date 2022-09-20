using System;
using System.Reflection;

namespace PhotoTools.Utils.Function;

public static partial class Get
{
    private static AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();
    public static string? GetCurrentName()
    {
        return _assemblyName.Name;
    }
    public static Version? GetCurrentVersion { get; } = _assemblyName.Version;
}