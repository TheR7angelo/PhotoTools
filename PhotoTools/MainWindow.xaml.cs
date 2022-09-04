using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using PhotoTools.Utils.Config;


namespace PhotoTools
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
            InitializeUi();

            //Config.Changelanguage("English");

            //const string path = @"E:\Logiciels\Adobe\Creative Cloud Files\Programmation\C#\Personnel\PhotoTools\PhotoTools\Test";
            //const string path = @"C:\Users\ZP6177\Creative Cloud Files\Programmation\C#\Personnel\PhotoTools\PhotoTools\Test";
            //Folder.CreateFolderMonth(2022, path);
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
            Console.WriteLine("open settings");
        }

        private void InitializeUi()
        {
            var v = Utils.Getter.Application.GetCurrentVersion;
            Title = Utils.Getter.Application.GetCurrentName();
            
            BtMainGithub.ToolTip = Utils.Trad.MainWindows.BtGithubToolTip;
        }

        private void OnApplicationExit(object? sender, CancelEventArgs e)
        {
            Sql.Connection.CloseBdds();
        }
    }
}