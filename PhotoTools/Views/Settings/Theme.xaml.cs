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
        }
        CbStyle.SelectedValue = Config.Configue.Theme.Name;
    }

    private void ButtonThemesBackground(StrucConfig.Themes theme)
    {
        foreach (var button in _listButton!)
        {
            foreach (var value in theme.Value.Where(value => value.Name.Equals(button.Name)))
            {
                button.Background = value.StyleValue;
                break;
            }
        }
    }
    private void ButtonThemesTooltip()
    {
        
        foreach (var button in _listButton!)
        {
            ButtonThemeToolTip(button);
        }
    }

    public static void ButtonThemeToolTip(Control button)
    {
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

    private void Rgb_OnClick(object sender, RoutedEventArgs e)
    {
        if (!(bool)ThemeLock.Tag)
        {
            var btn = (Button)sender;
            var background = ((SolidColorBrush)btn.Background).Color;
            var red = background.R;
            var green = background.G;
            var blue = background.B;

            ColorEdit.InstanceColorEdit!.ColorPicker.Color.RGB_R = red;
            ColorEdit.InstanceColorEdit.ColorPicker.Color.RGB_G = green;
            ColorEdit.InstanceColorEdit.ColorPicker.Color.RGB_B = blue;
            ColorEdit.InstanceColorEdit.Btn = btn;

            MainSettingView.InstanceMainSettingView!.ChangeTabItem("TabColorChange");
        }
        else
        {
            Console.WriteLine("Sorry but this theme is locked");
        }
    }

    private void CbStyle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CbStyle.SelectedItem == null) return;
        var selectedTheme = CbStyle.SelectedItem.ToString();

        var theme = Requete.GetStyle(selectedTheme!);

        ButtonThemesBackground(theme);
        ButtonThemesTooltip();
        
        ThemeLock.Source = (ImageSource)Application.Current.FindResource(GetImgLock(theme))!;
        ThemeLock.Tag = theme.Lock;
        ThemeLock.ToolTip = new ToolTip() { Content = $"Lock = {theme.Lock}" };
    }
    private static string GetImgLock(StrucConfig.Themes theme)
    {
        // return theme.Lock ? "Login006-Lock-2" : "Login002-Unlock";
        return theme.Lock ? "Login006-Lock-2" : "BasicUi089-Trash";
    }
}