using System.Diagnostics;

namespace PhotoTools.Utils.Function.Application;

public static class Current
{
    public static void Restart()
    {
        Process.Start(System.Environment.ProcessPath!);
        Process.GetCurrentProcess().Kill();
    }
}