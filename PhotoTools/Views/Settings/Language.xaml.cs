using System.Windows;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Sql;

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
        BtSettingLanguageValid.Content = Utils.Trad.Setting.MainSetting.BtLanguageValid.Normalize();
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
        msg.SetIcon(msg.MessageIcon.Question);
        msg.SetTitle(Utils.Trad.Setting.Language.Title);
        msg.SetText(Utils.Trad.Setting.Language.Message);
        msg.ShowDialog();
        var answer = msg.Answer;

        if (answer is not null && answer.Equals("yes")) Utils.Function.Application.Current.Restart();
    }
}