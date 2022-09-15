using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using PhotoTools.Sql;
using PhotoTools.Utils;
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
        _listButton = new List<Button> { RgbM1, RgbM2, RgbM3, RgbB1, RgbB2, RgbB3 };
        FillComboStyle();
    }

    private void FillComboStyle(string? name=null)
    {
        CbStyle.Items.Clear();
        var themes = Query.GetAllThemes();
        foreach (var theme in themes)
        {
            CbStyle.Items.Add(theme.Name);
        }

        name ??= Config.Configue.Theme.Name;
        CbStyle.SelectedValue = name;
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
        var color = ((SolidColorBrush)button.Background).Color;
        var red = color.R;
        var green = color.G;
        var blue = color.B;
        var hexa = color.ToHex();

        var colorTitre = new TextBlock { Text = Utils.Trad.ColorEdit.ButtonThemeToolTip, Margin = new Thickness(3) };
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
            //todo afficher un message d'erreur car le theme est non modifiable
            Console.WriteLine("Sorry but this theme is locked");
        }
    }

    private void CbStyle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        AddNewThemeVisibility(false);

        if (CbStyle.SelectedItem == null) return;
        var selectedTheme = CbStyle.SelectedItem.ToString();

        var theme = Query.GetStyle(selectedTheme!);

        ButtonThemesBackground(theme);
        ButtonThemesTooltip();

        ThemeLock.Source = (ImageSource)Application.Current.FindResource(GetImgLock(theme))!;
        ThemeLock.Tag = theme.Lock;
        ThemeLock.ToolTip = new ToolTip() { Content = $"Lock = {theme.Lock}" };
    }

    private static string GetImgLock(StrucConfig.Themes theme)
    {
        return theme.Lock ? "Login006-Lock-2" : "Login002-Unlock";
        //return theme.Lock ? "Login006-Lock-2" : "BasicUi067-Plus";
    }

    private void BtNewTheme_OnClick(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("add new theme");
        AddNewThemeVisibility(true);
    }

    private void AddNewThemeVisibility(bool newTheme)
    {
        if (newTheme)
        {
            BtNewTheme.IsEnabled = !newTheme;
            BtNewThemeValid.Visibility = Visibility.Visible;
            TbxStyle.Visibility = Visibility.Visible;
            TbxStyle.Text = string.Empty;
        }
        else
        {
            BtNewTheme.IsEnabled = !newTheme;
            BtNewThemeValid.Visibility = Visibility.Hidden;
            TbxStyle.Visibility = Visibility.Hidden;
        }
    }

    private void AddNewStyle_OnClick(object sender, RoutedEventArgs e)
    {
        var name = TbxStyle.Text;

        if (name.Equals(string.Empty))
        {
            // todo Message pour avertir que le nom du thème ne peut pas etre vide
            Console.WriteLine("Le nom ne peut pas étre vide");
        }
        // todo use this function
        else if (Query.GetThemeExist(name))
        {
            // todo Message pour avertir que le nom du thème ne peut pas etre deja utiliser
            Console.WriteLine("Nom deja utilisé");
        }
        else
        {
            // todo fonction pour enregistrer le theme
            var th = new StrucConfig.Themes
            {
                Name = name,
                Value = new List<StrucConfig.StyleColorBrush>()
            };

            foreach (var btn in _listButton!)
            {
                th.Value.Add(new StrucConfig.StyleColorBrush
                {
                    Name = btn.Name.Insert(3, "_").ToLower(),
                    StyleValue = (SolidColorBrush)btn.Background
                });
            }

            var apply = Query.AddTheme(th);
            // todo ajout un message si enregistrement réussi ou non

            if (apply)
            {
                Console.WriteLine("new theme: yes");
                FillComboStyle(name);
                AddNewThemeVisibility(false);
                return;
            }
            Console.WriteLine("new theme: non");

        }
    }
}