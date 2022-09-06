using System;
using System.Windows;
using System.Windows.Controls;

namespace PhotoTools.Views;

public partial class MainSettingView : UserControl
{
    public MainSettingView()
    {
        InitializeComponent();
    }

    private void BtTabItemTheme_OnClick(object sender, RoutedEventArgs e){ChangeTabItem(((Button)sender).Name);}
    private void BtTabItemLanguage_OnClick(object sender, RoutedEventArgs e){ChangeTabItem(((Button)sender).Name);}

    private void ChangeTabItem(string tab)
    {
        switch (tab)
        {
            case "BtTabSettingLanguage":
                TabLanguage.IsSelected = true;
                break;
            case "BtTabSettingTheme":
                TabTheme.IsSelected = true;
                break;
        }
    }
}