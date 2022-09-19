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

        public ImageSource Information { get; } = (ImageSource)Application.Current.Resources["BasicUi050-Info"];
        public ImageSource Warning { get; } = (ImageSource)Application.Current.Resources["BasicUi091-Warning"];
        public ImageSource Stop { get; } = (ImageSource)Application.Current.Resources["BasicUi076-Remove"];

    }
}