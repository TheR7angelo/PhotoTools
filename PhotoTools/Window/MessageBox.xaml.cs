using System.Windows;
using System.Windows.Media;

namespace PhotoTools.Window;

public partial class MessageBox
{
    public Utils.Strucs.MessageBox.Icon MessageIcon = new();
    public MessageBox()
    {
        InitializeComponent();

        SetDefaultValue();
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

    private void SetDefaultValue()
    {
        SetSize(new Size { Height = 250, Width = 500 });
        SetIcon(MessageIcon.Information);
        SetText(string.Empty);
        // todo changer le titre
        Title = "Information";
    }
}