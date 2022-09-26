using PhotoTools.Utils.Function.Application;

namespace PhotoTools.Window;

public partial class MainSetting
{
    public MainSetting()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        Title = Utils.Trad.Setting.MainSetting.Title;
        
        this.MetroWindowRightButton();
    }
    
    
}