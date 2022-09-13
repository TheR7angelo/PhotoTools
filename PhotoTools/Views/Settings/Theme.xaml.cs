using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using PhotoTools.Sql;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Views.Settings;

public partial class Theme
{
    private List<Button>? _listButton;

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
        _listButton = new List<Button>{ RgbM1, RgbM2, RgbM3, RgbB1, RgbB2, RgbB3 };
        FillComboStyle();
    }

    private void FillComboStyle()
    {
        CbStyle.Items.Clear();
        var themes = Requete.GetAllThemes();
        foreach (var theme in themes)
        {
            CbStyle.Items.Add(theme.Name);
            // if (!theme.Name.Equals(Config.Configue.Theme.Name)) continue;
            // ThemeLock.Source = (ImageSource)Application.Current.FindResource(GetImgLock(theme))!;
        }
        CbStyle.SelectedValue = Config.Configue.Theme.Name;
    }

    private void ButtonTheme(StrucConfig.Themes theme)
    {
        
        foreach (var button in _listButton!)
        {
            foreach (var value in theme.Value.Where(value => value.Name.Equals(button.Name)))
            {
                button.Background = value.StyleValue;
                break;
            }
            
            var background = ((SolidColorBrush)button.Background).Color;
            var red = background.R;
            var green = background.G;
            var blue = background.B;
            var hexa = $"{red:X}{green:X}{blue:X}";

            var colorTitre = new TextBlock { Text = "Red:\nGreen:\nBlue:\nHexa:", Margin = new Thickness(3) };
            var colorValue = new TextBlock
            {
                Text = $"{red}\n{green}\n{blue}\n{hexa}", Margin = new Thickness(3), TextAlignment = TextAlignment.Center
            };

            var stack = new StackPanel { Orientation = Orientation.Horizontal, Children = { colorTitre, colorValue } };

            button.ToolTip = new ToolTip
                { Placement = PlacementMode.Center, StaysOpen = true, IsOpen = false, Content = stack };
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

    private void CbStyle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CbStyle.SelectedItem == null) return;
        var selectedTheme = CbStyle.SelectedItem.ToString();

        var theme = Requete.GetStyle(selectedTheme!);
        
        ButtonTheme(theme);
        
        ThemeLock.Source = (ImageSource)Application.Current.FindResource(GetImgLock(theme))!;
        }
    private static string GetImgLock(StrucConfig.Themes theme)
    {
        var nameImg = theme.Lock ? "Login006-Lock-2" : "Login002-Unlock";
        return nameImg;
    }
}