using System.Windows;
using System.Windows.Media;

namespace PhotoTools.Utils.Strucs;

public class MessageBox
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

        public ImageSource Check { get; } = (ImageSource)Application.Current.Resources["BasicUi008-Check"];
        public ImageSource Information { get; } = (ImageSource)Application.Current.Resources["BasicUi050-Info"];
        public ImageSource Error { get; } = (ImageSource)Application.Current.Resources["BasicUi076-Remove"];
        public ImageSource Question { get; } = (ImageSource)Application.Current.Resources["BasicUi073-Question"];
        public ImageSource Warning { get; } = (ImageSource)Application.Current.Resources["BasicUi091-Warning"];
    }
}