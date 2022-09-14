namespace PhotoTools.Views.Settings;

public partial class ColorEdit
{
    public static ColorEdit? InstanceColorEdit { get; private set; }
    public ColorEdit()
    {
        InstanceColorEdit = this;
        InitializeComponent();
    }
}