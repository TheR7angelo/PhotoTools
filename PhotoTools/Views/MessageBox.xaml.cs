using System;
using System.Windows;
using System.Windows.Media;

namespace PhotoTools.Views;

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

    private void SetDefaultValue()
    {
        SetIcon(MessageIcon.Information);
        SetText(string.Empty);
    }
}