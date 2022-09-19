using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Sql;
using PhotoTools.Views;

namespace PhotoTools.Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow
    {
        public MainWindow()
        {
            Config.InitializeApp();
            InitializeComponent();
            Config.InitializeStyle();

            var msg = new MessageBox();
            msg.SetIcon(msg.MessageIcon.Stop);
            msg.SetText("Yo je suis un test");
            msg.SetSize(new Size{Height = 250, Width = 500});
            msg.ShowDialog();
            
            // ToastNotificationManagerCompat.OnActivated += toastArgs =>
            // {
            //     var args = ToastArguments.Parse(toastArgs.Argument);
            //     Console.WriteLine(args["action"]);
            // };
            
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

            InitializeUi();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = Constant.Directory.GithubPage,
                UseShellExecute = true
            });
        }

        private void BtSettings_OnClick(object sender, RoutedEventArgs e)
        {
            var setting = new MainSetting();
            setting.ShowDialog();
            // Console.WriteLine("open settings");
            // Config.InitializeStyle();
        }

        private void InitializeUi()
        {
            var v = Utils.Getter.Application.GetCurrentVersion;
            
            ToolTips();
        }

        private void ToolTips()
        {
            BtMainGithub.ToolTip = Utils.Trad.MainWindows.BtGithubToolTip;
            BtMainSetting.ToolTip = Utils.Trad.MainWindows.BtMainSetting;

            WindowButtonCommands.Minimize = "Réduire";
            WindowButtonCommands.Maximize = "Agrandir";
            WindowButtonCommands.Restore = "Rétrécir";
            WindowButtonCommands.Close = "Quitter";
        }

        private void OnApplicationExit(object? sender, CancelEventArgs e)
        {
            Connection.CloseBdds();
        }
    }
}