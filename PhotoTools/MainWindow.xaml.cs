using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Interop;
using PhotoTools.Sql;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Create;

namespace PhotoTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Config.InitializeApp();
            ChangeLanguage();
            
            Config.Changelanguage("French");

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

        private void ChangeLanguage()
        {
            BtMainGithub.ToolTip = Utils.Trad.MainWindow.BtGithubToolTip;
        }
    }
}