using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PhotoTools.Utils.Strucs;
using PhotoTools.Utils.Function.Application;

namespace PhotoTools.Views.Settings;

public partial class License
{
    private readonly Style _style = (Application.Current.Resources["ButtonImageLicence"] as Style)!;
    public License()
    {
        InitializeComponent();
        
        AddImages(Utils.Img.Pack.Image.ImageBasicUi, WrapPanelBasicUi);
        AddImages(Utils.Img.Pack.Image.ImageLogin, WrapPanelLogin);
    }

    private void AddImages(Images.LicenceImages pack, Panel panel)
    {
        foreach (var image in pack.Images.OrderBy(item => item).Select((value, i) => new { i, value }))
        {
            var btn = new Button
            {
                Name = $"{pack.PackName}_{image.i}",
                Content = new Image { Source =  Utils.Function.Get.GetResourcesImageSource(image.value)},
                Style = _style,
                Tag = pack.Url,
                
                // todo make tooltip interactif
                ToolTip = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children = { 
                        new TextBlock { Text= Utils.Trad.Setting.License.ButtonToolTip },
                        new TextBlock { Text = $"{pack.Author}\n{pack.Url}" }
                    }
                }
            };
            btn.Click += ButtonImageLicence_OnClick;
            panel.Children.Add(btn);
        }
    }

    private static void ButtonImageLicence_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var msg = new Window.MessageBox();
        msg.SetTitle(Utils.Trad.Setting.License.ButtonImageLicence_OnClick_Title);
        msg.SetIcon(msg.MessageIcon.Question);
        msg.SetText(Utils.Trad.Setting.License.ButtonImageLicence_OnClick_Content);
        msg.SetButtonYesNo();
        msg.ShowDialog();
        
        if (msg.Answer is not null && msg.Answer.Equals(msg.AnswerYes))
        {
            ((string)btn!.Tag).OpenUrl();
        }
    }
}