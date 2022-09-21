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
        // todo add licence name and go to url
        foreach (var image in pack.Images.OrderBy(item => item).Select((value, i) => new { i, value }))
        {
            var btn = new Button
            {
                Name = $"{pack.PackName}_{image.i}",
                Content = new Image { Source =  Utils.Function.Get.GetResourcesImageSource(image.value)},
                Style = _style,
                Tag = pack.Url,
                
                //todo make string trad
                ToolTip = $"Author: {pack.Author}\nUrl: {pack.Url}"
            };
            btn.Click += ButtonImageLicence_OnClick;
            panel.Children.Add(btn);
        }
    }

    private static void ButtonImageLicence_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        // todo make string trad
        var msg = new Window.MessageBox();
        msg.SetTitle("Question");
        msg.SetIcon(msg.MessageIcon.Question);
        msg.SetText("Open web page ?");
        msg.SetButtonYesNo();
        msg.ShowDialog();

        if (msg.Answer is "yes")
        {
            ((string)btn!.Tag).OpenUrl();
        }
    }
}