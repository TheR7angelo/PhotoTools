using System;
using System.Diagnostics;
using System.Windows;
using PhotoTools.Utils;
using PhotoTools.Sql;
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
            Requete.InitializeBdd();

            Fonction.Changelanguage("French");
            Folder.Main(2022);

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName = "https://www.google.fr",
                UseShellExecute = true
            });
        }
    }
}