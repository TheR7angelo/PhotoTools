using System;
using System.Reflection;

namespace PhotoTools.Utils.Getter;

public class AApplication
{
    public static Version? GetCurrentVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version;
}