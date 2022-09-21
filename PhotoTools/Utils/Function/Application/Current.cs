using System.Diagnostics;

namespace PhotoTools.Utils.Function.Application;

public static class Current
{
    public static void Restart()
    {
        Process.Start(System.Environment.ProcessPath!);
        Process.GetCurrentProcess().Kill();
    }

    public static void OpenUrl(this string url)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}