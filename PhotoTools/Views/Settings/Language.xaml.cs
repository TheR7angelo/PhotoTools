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
        
        var lang = Config.Configue.Language.LanguageName;
        var languages = Query.GetAllLangs(lang!);

        foreach (var langue in languages)
        {
            CbSettingLanguage.Items.Add(langue);
        }
    }

    private void BtSettingLanguageValid_OnClick(object sender, RoutedEventArgs e)
    {
        var lang = CbSettingLanguage.Text;
        if (lang == string.Empty) return;
        
        var newLang = Query.GetEnglishLang(lang);
        Config.Changelanguage(newLang);
        
        //todo a refaire
        // var msg = new MessageBox
        // {
        //     LbMsg ={ Text = Utils.Trad.SettingLanguage.BtSettingLanguageValideMsg},
        //     ImgIcon ={Source = MessageBox.Icon.Valid},
        //     Title = Utils.Trad.SettingLanguage.BtSettingLanguageValide
        // };
        // msg.Show();
        var msg = new Window.MessageBox();
        msg.SetButtonOk();
        // todo make icon valid
        msg.SetIcon(msg.MessageIcon.Information);
        msg.SetTitle("Validation");
        msg.ShowDialog();
        //todo add resource string
        // msg.SetText(Utils.Trad.SettingLanguage.BtSettingLanguageValideMsg);
        InitializeUi();
    }
}