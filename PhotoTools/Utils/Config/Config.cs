using System.Configuration;
using System.Globalization;
using PhotoTools.Constant;
using PhotoTools.Sql;
using PhotoTools.Utils.Getter;

namespace PhotoTools.Utils.Config;

public static class Config
{
    public static Configuration Configuration { get; } = GetPath.GetConfig();
    public static string LanguageName { get; set; } = null!;
    public static string LanguageCode { get; set; } = null!;

    public static void InitializeApp()
    {
        var appSettings = Configuration.AppSettings.Settings;
        LanguageName = appSettings["LanguageName"].Value;
        LanguageCode = appSettings["LanguageCode"].Value;

        Language.CultureInfo = new CultureInfo(appSettings["LanguageCode"].Value);
    }
    
    public static Configuration InitConfig(string path)
    {
        var map = new ExeConfigurationFileMap {ExeConfigFilename = path};
        var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

        var code = CultureInfo.CurrentCulture.Name;
        var lang = Requete.GetCultureInfoLang(code);

        config.AppSettings.Settings.Add("LanguageName", lang);
        config.AppSettings.Settings.Add("LanguageCode", code);
        
        
        config.Save(ConfigurationSaveMode.Full, true);
        return config;
    }
    public static void Changelanguage(string lang)
    {
        var code = Requete.GetCultureInfoCode(lang);
        
        LanguageName = lang;
        LanguageCode = code;

        var config = Config.Configuration;
        var settings = config.AppSettings.Settings;

        settings["LanguageName"].Value = lang;
        settings["LanguageCode"].Value = code;
        config.Save();

        Language.CultureInfo = new CultureInfo(code);

    }
}