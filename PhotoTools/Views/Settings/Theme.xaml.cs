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
        _listButton = new List<Button> { RgbM1, RgbM2, RgbM3, RgbB1, RgbB2, RgbB3 };
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

        var theme = Requete.GetStyle(selectedTheme!);

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
        //todo make function to add new theme theme
        Console.WriteLine("add new theme");
        AddNewThemeVisibility(true);
    }

    private void AddNewThemeVisibility(bool newTheme)
    {
        if (newTheme)
        {
            CbStyle.Text = string.Empty;
            BtNewTheme.IsEnabled = false;
            CbStyle.IsEditable = newTheme;
            BtNewThemeValid.Visibility = Visibility.Visible;
        }
        else
        {
            BtNewTheme.IsEnabled = true;
            CbStyle.IsEditable = newTheme;
            BtNewThemeValid.Visibility = Visibility.Hidden;
        }
    }

    private void AddNewStyle_OnClick(object sender, RoutedEventArgs e)
    {
        var name = CbStyle.Text;

        if (name.Equals(string.Empty))
        {
            // todo Message pour avertir que le nom du thème ne peut pas etre vide
            Console.WriteLine("Le nom ne peut pas étre vide");
        }
        else if (name.Equals("deja existant"))
        {
            // todo Message pour avertir que le nom du thème ne peut pas etre deja utiliser
            // todo check pour nom en doublon
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

            var apply = Requete.AddTheme(th);
            // todo ajout un message si enregistrement réussi ou non
            Console.WriteLine("hey");
            var txt = apply ? "Yes" : "No";
            Console.WriteLine($"new theme: {txt}");
        }
    }
}