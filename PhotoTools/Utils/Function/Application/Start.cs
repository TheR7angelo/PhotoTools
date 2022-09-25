using System.Diagnostics;

namespace PhotoTools.Utils.Function.Application;

public static class Start
{
    public static void OpenUrl(this string url)
    {
        url._Start();
    }

    public static void StartFile(this string path)
    {
        path._Start();
    }

    private static void _Start(this string path)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }
}