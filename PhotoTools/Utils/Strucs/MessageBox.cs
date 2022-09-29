using System.Windows;
using System.Windows.Media;
using PhotoTools.Utils.Function;

namespace PhotoTools.Utils.Strucs;

public static class MessageBox
{
    public struct Button
    {
        public string Name;
        public string Content;
    }
    
    public struct Icon
    {
        public Icon()
        {
        }

        public ImageSource Check { get; } = "BasicUi008-Check".GetResourcesImageSource();// (ImageSource)Application.Current.Resources["BasicUi008-Check"];
        public ImageSource Information { get; } = "BasicUi050-Info".GetResourcesImageSource();//(ImageSource)Application.Current.Resources["BasicUi050-Info"];
        public ImageSource Error { get; } = "BasicUi076-Remove".GetResourcesImageSource();//(ImageSource)Application.Current.Resources["BasicUi076-Remove"];
        public ImageSource Question { get; } = "BasicUi073-Question".GetResourcesImageSource();//(ImageSource)Application.Current.Resources["BasicUi073-Question"];
        public ImageSource Warning { get; } = "BasicUi091-Warning".GetResourcesImageSource();//(ImageSource)Application.Current.Resources["BasicUi091-Warning"];
    }
}