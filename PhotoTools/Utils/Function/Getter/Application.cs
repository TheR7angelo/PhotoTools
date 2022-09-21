using System;
using System.Reflection;
using System.Windows.Media;

namespace PhotoTools.Utils.Function;

public partial class Get
{
    private static AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();
    public static string? GetCurrentName()
    {
        return _assemblyName.Name;
    }
    public static Version? GetCurrentVersion { get; } = _assemblyName.Version;

    public static ImageSource GetImageSourceResources(string key)
    {
        return (System.Windows.Application.Current.Resources[key] as ImageSource)!;
    }
}