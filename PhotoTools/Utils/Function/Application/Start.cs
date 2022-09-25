using System.Diagnostics;

namespace PhotoTools.Utils.Function.Application;

public static class Start
{
    public static void OpenUrl(this string url)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    public static void StartFile(this string path)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = path,
            UseShellExecute = true
        });
    }
}