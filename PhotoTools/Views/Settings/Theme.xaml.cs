using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace PhotoTools.Views.Settings;

public partial class Theme : UserControl
{
    public Theme()
    {
        InitializeComponent();
        Ui();
    }
    
    // private void Th_OnClick(object sender, RoutedEventArgs e)
    // {
    //     var r = (int)Math.Round(pixieColor.Color.RGB_R);
    //     var g = (int)Math.Round(pixieColor.Color.RGB_G);
    //     var b = (int)Math.Round(pixieColor.Color.RGB_B);
    //
    //     var t = r.ToString("X");
    //     var y = g.ToString("X");
    //     var u = b.ToString("X");
    //     var hex = $"FF{t}{y}{u}";
    //     Console.WriteLine(hex);
    // }

    private void Ui()
    {
        var buttons = new List<Button> { RgbM1, RgbM2, RgbM3, RgbB1, RgbB2, RgbB3 };
        foreach (var button in buttons)
        {
            var toolTip = new ToolTip(){Placement = PlacementMode.Bottom, StaysOpen = true, IsOpen = false};
            
            
            
            button.ToolTip = toolTip;
        }
    }
    private void Rgb_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        var background = ((SolidColorBrush)btn.Background).Color;
        var red = background.R;
        var green = background.G;
        var blue = background.B;
        
        Console.WriteLine($@"{red} {green} {blue}");
    }
}