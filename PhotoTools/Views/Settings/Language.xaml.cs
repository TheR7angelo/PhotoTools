using System;
using System.Windows;
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

        BtSettingLanguageValid.Content = Utils.Trad.MainSetting.BtSettingLanguageValid.Normalize();
    }

    private void FillComboLanguage()
    {
        CbSettingLanguage.Items.Clear();
        
        var lang = Config.Configue.Language.LanguageName;
        var languages = Requete.GetAllLangs(lang!);

        foreach (var langue in languages)
        {
            CbSettingLanguage.Items.Add(langue);
        }
    }

    private void BtSettingLanguageValid_OnClick(object sender, RoutedEventArgs e)
    {
        var lang = CbSettingLanguage.Text;
        if (lang == string.Empty) return;
        
        var newLang = Requete.GetEnglishLang(lang);
        Config.Changelanguage(newLang);
        
        var msg = new MessageBox
        {
            Title = Utils.Trad.MainSetting.BtSettingLanguageValid,
            LbMsg ={ Text = Utils.Trad.MainSetting.BtSettingLanguageValideMsg },
            ImgIcon ={ Source = MessageBox.Icon.Valid },
        };
        msg.Show();
        InitializeUi();
    }
}