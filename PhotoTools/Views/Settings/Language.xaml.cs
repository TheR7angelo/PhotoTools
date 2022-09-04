using PhotoTools.Sql;
using PhotoTools.Utils.Config;

namespace PhotoTools.Views.Settings;

public partial class Language
{
    public Language()
    {
        InitializeComponent();
        InitializeUi();
    }

    private void InitializeUi()
    {
        FillComboLanguage();

        BtSettingLanguageValide.Content = Utils.Trad.SettingLanguage.BtSettingLanguageValide.Normalize();
    }

    private void FillComboLanguage()
    {
        var lang = Config.Configue.Language.LanguageName;
        var languages = Requete.GetAllLangs(lang!);

        foreach (var langue in languages)
        {
            CbSettingLanguage.Items.Add(langue);
        }
    }
}