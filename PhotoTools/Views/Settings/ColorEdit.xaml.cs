using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PhotoTools.Views.Settings;

public partial class ColorEdit
{
    public static ColorEdit? InstanceColorEdit { get; private set; }
    public Button Btn { get; set; } = new();
    public ColorEdit()
    {
        InstanceColorEdit = this;
        InitializeComponent();

        InitializedUi();
    }

    private void InitializedUi()
    {
        BtCancel.Content = Utils.Trad.Setting.ColorEdit.BtCancelContent;
        BtValid.Content = Utils.Trad.Setting.ColorEdit.BtValidContent;
    }

    private void BtColorEditValidation_OnClick(object sender, RoutedEventArgs e)
    {
        var red = (byte)ColorPicker.Color.RGB_R;
        var green = (byte)ColorPicker.Color.RGB_G;
        var blue = (byte)ColorPicker.Color.RGB_B;
        Btn.Background = new SolidColorBrush(Color.FromArgb(255, red, green, blue));
        Theme.ButtonThemeToolTip(Btn);
        Exit();
    }

    private void BtColorEditAnnul_OnClick(object sender, RoutedEventArgs e)
    {
        Exit();
    }

    private static void Exit()
    {
        MainSettingView.InstanceMainSettingView!.ChangeTabItem("RdBtSettingTabTheme");
    }
}