using System.Windows;
using PhotoTools.Utils.Config;
using Query = PhotoTools.Utils.Function.Sql.Query;

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
        var cultureLang = Query.GetActualcultureLang(lang);
        var languages = Query.GetAllLangs(lang);

        foreach (var language in languages)
        {
            if (language.Equals(cultureLang)) continue;
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

        if (msg.Answer is not null && msg.Answer.Equals(msg.AnswerYes)) Utils.Function.Application.Current.Restart();
    }
}