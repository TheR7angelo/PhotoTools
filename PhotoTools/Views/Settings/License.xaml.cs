using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Views.Settings;

public partial class License
{
    private readonly Style _style = (Application.Current.Resources["ButtonImage"] as Style)!;
    public License()
    {
        InitializeComponent();
        
        AddImages(Utils.Img.Pack.Image.ImageBasicUi, WrapPanelBasicUi);
        AddImages(Utils.Img.Pack.Image.ImageLogin, WrapPanelLogin);
    }

    private void AddImages(Images.LicenceImages pack, Panel panel)
    {
        var url = pack.Url;
        var author = pack.Author;
        // todo add licence name and go to url
        foreach (var image in pack.Images.OrderBy(item => item))
        {
            var btn = new Button
            {
                Content = new Image { Source =  Utils.Function.Get.GetImageSourceResources(image)},
                Style = _style,
                ToolTip = image
            };

            panel.Children.Add(btn);
        }
    }
}