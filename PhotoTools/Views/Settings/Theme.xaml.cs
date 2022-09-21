using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Microsoft.Win32;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Function;
using PhotoTools.Utils.Sql;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Views.Settings;

public partial class Theme
{
    private List<Button>? ListButton { get;}

    public Theme()
    {
        InitializeComponent();
        ListButton = new List<Button> { RgbM1, RgbM2, RgbM3, RgbB1, RgbB2, RgbB3 };
        Ui();
    }

    #region Function

    private void AddNewThemeVisibility(bool newTheme)
    {
        if (newTheme)
        {
            BtNewTheme.IsEnabled = !newTheme;
            CbStyle.Visibility = Visibility.Hidden;
            BtNewThemePanel.Visibility = Visibility.Visible;
            TbxStyle.Visibility = Visibility.Visible;
            TbxStyle.Text = string.Empty;
        }
        else
        {
            BtNewTheme.IsEnabled = !newTheme;
            CbStyle.Visibility = Visibility.Visible;
            BtNewThemePanel.Visibility = Visibility.Hidden;
            TbxStyle.Visibility = Visibility.Hidden;
        }
    }
    
    private void ButtonThemesBackground(StrucConfig.Themes theme)
    {
        foreach (var button in ListButton!)
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
        foreach (var button in ListButton!)
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

        var colorTitre = new TextBlock { Text = Utils.Trad.Setting.Theme.ButtonThemeToolTip, Margin = new Thickness(3) };
        var colorValue = new TextBlock
        {
            Text = $"{red}\n{green}\n{blue}\n{hexa}", Margin = new Thickness(3), TextAlignment = TextAlignment.Center
        };

        var stack = new StackPanel { Orientation = Orientation.Horizontal, Children = { colorTitre, colorValue } };

        button.ToolTip = new ToolTip
            { Placement = PlacementMode.Center, StaysOpen = true, IsOpen = false, Content = stack };
    }

    private static string GetImgLock(StrucConfig.Themes theme)
    {
        return theme.Lock ? "Login006-Lock-2" : "Login002-Unlock";
    }
    
    private void Ui()
    {
        FillComboStyle();
        ContentButton();
    }

    #endregion

    #region Initialize

    private void ContentButton()
    {
        BtAddNewThemeValid.Content = Utils.Trad.Setting.Theme.BtAddNewThemeValid;
        BtAddNewThemeCancel.Content = Utils.Trad.Setting.Theme.BtAddNewThemeCancel;
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

    #endregion
    
    #region Action

    private void BtAddNewThemeValid_OnClick(object sender, RoutedEventArgs e)
    {
        var name = TbxStyle.Text;
        
        var msg = new Window.MessageBox();
        msg.SetTitle(Utils.Trad.Setting.Theme.ThemeLockTitle);
        msg.SetIcon(msg.MessageIcon.Warning);
        msg.SetButtonOk();
        
        if (name.Equals(string.Empty))
        {
            msg.SetText(Utils.Trad.Setting.Theme.EmptyThemeNameMessage);
        }
        else if (Query.GetThemeExist(name))
        {
            msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeNameExistMessage, name));
        }
        else
        {
            var th = new StrucConfig.Themes
            {
                Name = name,
                Value = new List<StrucConfig.StyleColorBrush>()
            };

            foreach (var btn in ListButton!)
            {
                th.Value.Add(new StrucConfig.StyleColorBrush
                {
                    Name = btn.Name.Insert(3, "_").ToLower(),
                    StyleValue = (SolidColorBrush)btn.Background
                });
            }

            var apply = Query.AddTheme(th);
            if (apply)
            {
                FillComboStyle(name);
                AddNewThemeVisibility(false);
                
                msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeAddedMessage, name));
            }
            else
            {
                msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeNotAddedMessage, name));
            }
        }
        msg.ShowDialog();
    }
    
    private void BtDelTheme_OnClick(object sender, RoutedEventArgs e)
    {
        var msg = new Window.MessageBox();
        var name = CbStyle.Text!;
        msg.SetTitle(Utils.Trad.Setting.Theme.ThemeDeleteTitleQuestion);
        msg.SetIcon(msg.MessageIcon.Question);
        msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeDeleteQuestion, name));
        msg.SetButtonYesNo();
        msg.ShowDialog();

        if (msg.Answer is not null && msg.Answer.Equals("yes"))
        {
            msg = new Window.MessageBox();
            msg.SetTitle(Utils.Trad.Setting.Theme.ThemeLockTitle);
            msg.SetIcon(msg.MessageIcon.Warning);
            if (!(bool)ThemeLock.Tag)
            {
                var apply = name.DeleteTheme();
                if (apply)
                {
                    FillComboStyle();
                    msg.SetTitle(Utils.Trad.Setting.Theme.ThemeDeleteTitleMessage);
                    msg.SetIcon(msg.MessageIcon.Check);
                    msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeDeleteTrueMessage, name));
                    msg.ShowDialog();
                }
                else
                {
                    msg.SetText(string.Format(Utils.Trad.Setting.Theme.ThemeDeleteFalseMessage, name));
                    msg.ShowDialog();
                }
            }
            else
            {
                msg.SetText(Utils.Trad.Setting.Theme.ThemeLockMessage);
                msg.ShowDialog();
            }
        }
    }

    private void BtAddNewThemeCancel_OnClick(object sender, RoutedEventArgs e)
    {
        AddNewThemeVisibility(((Button)sender).Equals(BtNewTheme));
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
            var msg = new Window.MessageBox();
            msg.SetButtonOk();
            msg.SetIcon(msg.MessageIcon.Warning);
            msg.SetTitle(Utils.Trad.Setting.Theme.ThemeLockTitle);
            msg.SetText(Utils.Trad.Setting.Theme.ThemeLockMessage);
            msg.ShowDialog();
        }
    }

    #endregion

    private void BtExpTheme_OnClick(object sender, RoutedEventArgs e)
    {
        // todo finish export ".json" file
        var name = CbStyle.Text!;
        var theme = Query.GetStyle(name);
        var ext = SaveFile();
        Console.WriteLine(name);
    }

    private void BtImpTheme_OnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private static string SaveFile()
    {
        // "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs"
        var saveFileDialog = new SaveFileDialog {
            Filter = "Json file (*.json)|*.json",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        };
        return saveFileDialog.ShowDialog() != true ? string.Empty : Path.GetExtension(saveFileDialog.FileName);
    }
}