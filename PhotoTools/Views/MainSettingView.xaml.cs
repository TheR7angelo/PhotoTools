using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PhotoTools.Views;

public partial class MainSettingView
{
    public MainSettingView()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void RdBtSettingTabLanguage_OnCheck(object sender, RoutedEventArgs e)
    {
        ChangeTabItem(((RadioButton)sender).Name);
    }

    private void RdBtTabItemTheme_OnCheck(object sender, RoutedEventArgs e)
    {
        ChangeTabItem(((RadioButton)sender).Name);
    }

    private void ChangeTabItem(string tab)
    {
        switch (tab)
        {
            case "RdBtSettingTabLanguage":
                TabLanguage.IsSelected = true;
                break;
            case "RdBtSettingTabTheme":
                TabTheme.IsSelected = true;
                break;
        }
    }

    private void InitializeUi()
    {
        RdBtSettingTabLanguage.Content = Utils.Trad.MainSetting.RdBtSettingTabLanguage;
        RdBtSettingTabLanguage.IsChecked = true;
        
        RdBtSettingTabTheme.Content = Utils.Trad.MainSetting.RdBtSettingTabTheme;
    }
}