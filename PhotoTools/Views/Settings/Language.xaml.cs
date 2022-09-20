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
        // todo move function
        BtSettingLanguageValid.Content = Utils.Trad.Setting.MainSetting.BtSettingLanguageValid.Normalize();
    }

    private void FillComboLanguage()
    {
        CbSettingLanguage.Items.Clear();
        
        var lang = Config.Configue.Language.LanguageName!;
        var languages = Query.GetAllLangs(lang);

        foreach (var language in languages)
        {
            CbSettingLanguage.Items.Add(language);
        }
    }

    private void BtSettingLanguageValid_OnClick(object sender, RoutedEventArgs e)
    {
        var lang = CbSettingLanguage.Text;
        if (lang == string.Empty) return;
        
        var newLang = Query.GetEnglishLang(lang);
        Config.Changelanguage(newLang);
        
        var msg = new Window.MessageBox();
        msg.SetButtonYesNo();
        // todo make icon question
        msg.SetIcon(msg.MessageIcon.Check);
        msg.SetTitle("Validation");
        msg.SetText(Utils.Trad.Setting.SettingLanguage.BtSettingLanguageValideMsg);
        msg.ShowDialog();
        var answer = msg.Answer;

        if (answer is not null && answer.Equals("yes")) Utils.Function.Application.Current.Restart();
    }
}