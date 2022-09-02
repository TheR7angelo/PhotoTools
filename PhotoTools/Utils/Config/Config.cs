using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using PhotoTools.Constant;
using PhotoTools.Sql;
using PhotoTools.Utils.Getter;

namespace PhotoTools.Utils.Config;

public static class Config
{
    private static Configuration Configuration { get; } = GetPath.GetConfig();
    private static KeyValueConfigurationCollection _settings = Configuration.AppSettings.Settings;
    public static string LanguageName { get; set; } = null!;
    public static string LanguageCode { get; set; } = null!;

    public static void InitializeApp()
    {
        Connection.InitializeBdds();
        LanguageName = _settings["LanguageName"].Value;
        LanguageCode = _settings["LanguageCode"].Value;

        Language.CultureInfo = new CultureInfo(_settings["LanguageCode"].Value);
        CultureInfo.CurrentUICulture = Language.CultureInfo;
    }
    
    public static Configuration InitConfig(string path)
    {
        var code = CultureInfo.CurrentCulture.Name;
        var lang = Requete.GetCultureInfoLang(code);

        if (lang == null)
        {
            code = "en-EN";
            lang = "English";
        }
        
        var map = new ExeConfigurationFileMap {ExeConfigFilename = path};
        var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        var settings = config.AppSettings.Settings;

        var cnfs = Requete.GetParams();
        
        foreach (var cnf in cnfs)
        {
            
            var cf =
                ConfigurationManager.GetSection("customAppSettingsGroup/customAppSettings") as
                    System.Collections.Specialized.NameValueCollection;
            cf.Add(cnf.Key, cnf.Value);
        }
        config.Save(ConfigurationSaveMode.Full, true);
        return config;
    }
    public static void Changelanguage(string lang)
    {
        var code = Requete.GetCultureInfoCode(lang);
        
        LanguageName = lang;
        LanguageCode = code;
        
        Language.CultureInfo = new CultureInfo(code);
        CultureInfo.CurrentUICulture = Language.CultureInfo;

        var cnfs = new List<Struc.ConfigStruc>
        {
            new (){ Key = "LanguageName", Value = lang },
            new () { Key = "LanguageCode", Value = code }
        };
        ModifyConfigs(cnfs);
    }

    private static void ModifyConfig(string key, string value)
    {
        _settings[key].Value = value;
        Configuration.Save();
    }

    private static void ModifyConfigs(List<Struc.ConfigStruc> keyValuesStrucs)
    {
        foreach (var cnf in keyValuesStrucs)
        {
            _settings[cnf.Key].Value = cnf.Value;
        }
        Configuration.Save();
    }
}