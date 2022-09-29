using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Constant;
using PhotoTools.Utils.Function.Application;
using PhotoTools.Utils.Function.Sql;

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

            InitializeUi();

            // TestFunction();

        }

        private static void TestFunction()
        {
            Current.ChangeIcon(new Bitmap(@"C:\Users\ZP6177\AppData\Local\Microsoft\Teams\current\resources\assets\favicon.png"),
                new Bitmap(@"C:\Users\ZP6177\AppData\Local\Microsoft\Teams\current\resources\assets\Badge_4.png"));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Directory.GithubPage.OpenUrl();
        }

        private void BtSettings_OnClick(object sender, RoutedEventArgs e)
        {
            var setting = new MainSetting();
            setting.ShowDialog();
        }

        private void InitializeUi()
        {
            var v = Utils.Function.Get.GetCurrentVersion;
            
            ToolTips();

            this.MetroWindowRightButton();
        }

        private void ToolTips()
        {
            BtMainGithub.ToolTip = Utils.Trad.Main.MainWindows.BtGithubToolTip;
            BtMainSetting.ToolTip = Utils.Trad.Main.MainWindows.BtMainSetting;
        }

        private void OnApplicationExit(object? sender, CancelEventArgs e)
        {
            Connection.CloseBdds();
        }
    }
}