using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using PhotoTools.Utils.Strucs;

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
        var url = pack.Url;
        var author = pack.Author;
        // todo add licence name and go to url
        foreach (var image in pack.Images.OrderBy(item => item))
        {
            var btn = new Button
            {
                Content = new Image { Source =  Utils.Function.Get.GetResourcesImageSource(image)},
                Style = _style,
                
                // ToolTip = new ToolTip{ Content = new TextBlock
                // {
                //     Text = $"Author: {author}\nUrl: {url}",
                //     Inlines = { new Hyperlink{ NavigateUri = new Uri(url)} }
                // }}
            };
            var popup = new Popup()
            {
                IsOpen = true,
                PlacementTarget = btn,
                Child = new TextBlock()
                {
                    Text = "yo mec"
                }
            };
            //btn.ToolTip = popup;

            panel.Children.Add(btn);
        }
    }
}