using System;
using System.Reflection;

namespace PhotoTools.Utils.Getter;

public class Application
{
    private static AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();
    public static string? GetCurrentName()
    {
        return _assemblyName.Name;
    }
    public static Version? GetCurrentVersion { get; } = _assemblyName.Version;
}