﻿using System.ComponentModel;
using System.Windows;
using MahApps.Metro.Controls;
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