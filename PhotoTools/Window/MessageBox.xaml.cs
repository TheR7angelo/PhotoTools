using System.Windows;
using System.Windows.Media;

namespace PhotoTools.Window;

public partial class MessageBox
{
    public Utils.Strucs.MessageBox.Icon MessageIcon = new();
    public string Answer = null!;
    public MessageBox()
    {
        InitializeComponent();
    }

    public void SetIcon(ImageSource icon)
    {
        ImgIcon.Source = icon;
    }

    public void SetText(string text)
    {
        LbMsg.Text = text;
    }

    public void SetSize(Size size)
    {
        Height = size.Height;
        Width = size.Width;
    }
}