using System.Diagnostics;
using MahApps.Metro.Controls;
using Microsoft.Toolkit.Uwp.Notifications;

namespace PhotoTools.Utils.Function.Application;

public static class Current
{
    public static void Restart()
    {
        Process.Start(System.Environment.ProcessPath!);
        Process.GetCurrentProcess().Kill();
    }

    public static void SendNotification(string title, string msg)
    {
        new ToastContentBuilder()
            .AddText(title)
            .AddText(msg)
            .Show();
        // ToastNotificationManagerCompat.OnActivated += toastArgs =>
        // {
        //     var args = ToastArguments.Parse(toastArgs.Argument);
        //     Console.WriteLine(args["action"]);
        // };
        //     
        // for (var i = 0; i < 2; i++)
        // {
        //     new ToastContentBuilder()
        //         .AddArgument("action", "viewConversation")
        //         .AddArgument("conversationId", 9813)
        //         .AddText("Andrew sent you a picture")
        //         .AddText("Check this out, The Enchantments in Washington!")
        //         .AddButton(new ToastButton()
        //             .SetContent("Archive")
        //             .AddArgument("action", "archive")
        //             .SetBackgroundActivation())
        //         .Show();
        // }
    }
    
    public static void MetroWindowRightButton(this MetroWindow window)
    {
        window.WindowButtonCommands.Close = Trad.MetroWindow.MetroWindow.Close;
        window.WindowButtonCommands.Maximize = Trad.MetroWindow.MetroWindow.Maximize;
        window.WindowButtonCommands.Minimize = Trad.MetroWindow.MetroWindow.Minimize;
        window.WindowButtonCommands.Restore = Trad.MetroWindow.MetroWindow.Restore;
    }
}