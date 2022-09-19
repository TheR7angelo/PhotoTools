using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace PhotoTools.Window;

public partial class MessageBox
{
    public Utils.Strucs.MessageBox.Icon MessageIcon = new();
    public string Answer { get; private set; } = null!;

    #region List Buttons
    private readonly List<Utils.Strucs.MessageBox.Button> _buttonsOk = new()
    {
        new Utils.Strucs.MessageBox.Button { Name = "Ok", Content = Utils.Trad.MessageBox.MessageBox.ButtonOk }
    };
    private readonly List<Utils.Strucs.MessageBox.Button> _buttonsYesNo = new()
    {
        new Utils.Strucs.MessageBox.Button { Name = "Yes", Content = Utils.Trad.MessageBox.MessageBox.ButtonYes },
        new Utils.Strucs.MessageBox.Button { Name = "No", Content = Utils.Trad.MessageBox.MessageBox.ButtonNo }
    };
    private readonly List<Utils.Strucs.MessageBox.Button> _buttonsYesNoCancel = new()
    {
        new Utils.Strucs.MessageBox.Button { Name = "Yes", Content = Utils.Trad.MessageBox.MessageBox.ButtonYes },
        new Utils.Strucs.MessageBox.Button { Name = "No", Content = Utils.Trad.MessageBox.MessageBox.ButtonNo },
        new Utils.Strucs.MessageBox.Button { Name = "Cancel", Content = Utils.Trad.MessageBox.MessageBox.ButtonCancel },
    };

    #endregion

    public MessageBox()
    {
        InitializeComponent();
        SetButtonOk();
        Title = Utils.Trad.MessageBox.MessageBox.Title;
    }

    #region Setter

    public void SetSize(Size size)
    {
        Height = size.Height;
        Width = size.Width;
    }

    public void SetTitle(string title) => Title = title;
    public void SetIcon(ImageSource icon) => ImgIcon.Source = icon;
    public void SetText(string text) => LbMsg.Text = text;
    
    public void SetButtonYesNo() => SetButtons(_buttonsYesNo);
    public void SetButtonYesNoCancel() => SetButtons(_buttonsYesNoCancel);
    public void SetButtonOk() => SetButtons(_buttonsOk);

    private void SetButtons(List<Utils.Strucs.MessageBox.Button> list)
    {
        ClearPanelButton();
        foreach (var button in list)
        {
            PanelButton.Children.Add(CreatButton(button.Name, button.Content));
        }
    }
    
    #endregion

    #region Function

    private void ClearPanelButton()
    {
        PanelButton.Children.Clear();
    }
    
    private Button CreatButton(string name, string content)
    {
        var btn = new Button()
        {
            Content = content,
            Name = name.ToLower(),
            Margin = new Thickness{Bottom = 3, Left = 3, Right = 3, Top = 3},
            Width = 50
        };
        btn.Click += ButtonAnswer_OnClick;
        return btn;
    }

    #endregion
    
    #region Action

    private void ButtonAnswer_OnClick(object sender, RoutedEventArgs e)
    {
        Answer = ((Button)sender).Name;
        DialogResult = true;
    }

    #endregion
}