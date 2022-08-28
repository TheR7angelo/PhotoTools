using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Xml.Schema;
using PhotoTools.Utils;
using PhotoTools.Sql;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Create;
using PhotoTools.Utils.Getter;

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
            Connection.InitializeBdds();
            Config.InitializeApp();

            Config.Changelanguage("French");
            const string path = @"E:\Logiciels\Adobe\Creative Cloud Files\Programmation\C#\Personnel\PhotoTools\PhotoTools\Test";
            Folder.Create(2022, path);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = Constant.Directory.GithubPage,
                UseShellExecute = true
            });
        }
    }
}