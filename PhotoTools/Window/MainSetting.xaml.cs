using System.Windows;

namespace PhotoTools;

public partial class MainSetting
{
    public MainSetting()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        Title = Utils.Trad.MainSetting.Title;
    }
    
    
}