using System;
using System.Reflection;
using System.Windows.Media;

namespace PhotoTools.Utils.Function;

public static partial class Get
{
    private static readonly AssemblyName AssemblyName = Assembly.GetExecutingAssembly().GetName();
    
    public static string? GetCurrentName() => AssemblyName.Name;
    public static Version? GetCurrentVersion { get; } = AssemblyName.Version;

    public static ImageSource GetResourcesImageSource(this string key) => (System.Windows.Application.Current.Resources[key] as ImageSource)!;
}