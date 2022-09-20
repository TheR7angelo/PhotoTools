using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Views.Settings;

public partial class License
{
    private Style _style = (Application.Current.Resources["ButtonImage"] as Style)!;
    public License()
    {
        InitializeComponent();
        
        AddImages(Utils.Img.Pack.Image.ImageBasicUi, WrapPanelBasicUi);
        AddImages(Utils.Img.Pack.Image.ImageLogin, WrapPanelLogin);
    }

    private void AddImages(Images.LicenceImages pack, Panel panel)
    {
        var url = pack.Url;
        // todo add licence name and go to url
        foreach (var image in pack.Images)
        {
            var btn = new Button
            {
                Content = new Image { Source = (Application.Current.Resources[image] as ImageSource)! },
                Style = _style,
                ToolTip = image
            };

            panel.Children.Add(btn);
        }
    }
}