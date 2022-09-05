using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Views.Settings;

public partial class MessageBox
{
    public new struct Icon
    {
        public static ImageSource Alert { get;} = new BitmapImage(new Uri(@"pack://application:,,,/Utils/Img/MessageBox/alert.png"));
        public static ImageSource Critical { get;} = new BitmapImage(new Uri(@"pack://application:,,,/Utils/Img/MessageBox/critical.png"));
        public static ImageSource Error { get;} = new BitmapImage(new Uri(@"pack://application:,,,/Utils/Img/MessageBox/error.png"));
        public static ImageSource Information { get;} = new BitmapImage(new Uri(@"pack://application:,,,/Utils/Img/MessageBox/information.png"));
        public static ImageSource Valid { get;} = new BitmapImage(new Uri($@"pack://application:,,,/Utils/Img/MessageBox/valid.png"));
    }
    public MessageBox()
    {
        InitializeComponent();
    }
}