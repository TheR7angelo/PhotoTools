﻿using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using PhotoTools.Constant;
using PhotoTools.Sql;
using PhotoTools.Utils.Getter;

namespace PhotoTools.Utils.Config;

public static class Config
{
    public static Configuration Configuration { get; } = GetPath.GetConfig();
    public static KeyValueConfigurationCollection Settings = Configuration.AppSettings.Settings;
    public static string LanguageName { get; set; } = null!;
    public static string LanguageCode { get; set; } = null!;

    public static void InitializeApp()
    {
        Connection.InitializeBdds();
        Settings = Configuration.AppSettings.Settings;
        LanguageName = Settings["LanguageName"].Value;
        LanguageCode = Settings["LanguageCode"].Value;

        Language.CultureInfo = new CultureInfo(Settings["LanguageCode"].Value);
    }
    
    public static Configuration InitConfig(string path)
    {
        var code = CultureInfo.CurrentCulture.Name;
        var lang = Requete.GetCultureInfoLang(code);
        
        var map = new ExeConfigurationFileMap {ExeConfigFilename = path};
        var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        var settings = config.AppSettings.Settings;

        var cnfs = new List<Struc.ConfigStruc>
        {
            new (){ Key = "LanguageName", Value = lang },
            new () { Key = "LanguageCode", Value = code },
            new () { Key = "Theme", Value = string.Empty },
        };
        
        foreach (var cnf in cnfs)
        {
            settings.Add(cnf.Key, cnf.Value);
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

        var cnfs = new List<Struc.ConfigStruc>
        {
            new (){ Key = "LanguageName", Value = lang },
            new () { Key = "LanguageCode", Value = code }
        };
        ModifyConfigs(cnfs);
    }

    private static void ModifyConfig(string key, string value)
    {
        Settings[key].Value = value;
        Configuration.Save();
    }

    private static void ModifyConfigs(List<Struc.ConfigStruc> keyValuesStrucs)
    {
        foreach (var cnf in keyValuesStrucs)
        {
            Settings[cnf.Key].Value = cnf.Value;
        }
        Configuration.Save();
    }
}