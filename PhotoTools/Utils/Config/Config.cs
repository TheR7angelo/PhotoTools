using System;
using System.Collections.Generic;
using System.Globalization;
using PhotoTools.Constant;
using PhotoTools.Sql;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Config;

public static class Config
{
    public static Strucs.StrucConfig.Configue Configue = new ();

    public static void InitializeApp()
    {
        Connection.InitializeBdds();
        var paramsStrucs = Requete.GetParams();
        double screenSize;

        foreach (var param in paramsStrucs)
        {
            switch (param.Section)
            {
                case "Language":
                    switch (param.Key)
                    {
                        case "LanguageName":
                            Configue.Language.LanguageName = param.Value;
                            break;
                        case "LanguageCode":
                            Configue.Language.LanguageCode = param.Value;
                            break;
                    }
                    break;
                case "Theme":
                    Configue.Theme = param.Value;
                    break;
                case "ScreenSize":
                    screenSize = double.Parse(param.Value!);
                    switch (param.Key)
                    {
                        case "MinWidth":
                            Configue.ScreenSize.MinWidth = screenSize;
                            break;
                        case "MinHeight":
                            Configue.ScreenSize.MinHeight = screenSize;
                            break;
                    }
                    break;
            }
        }

        Language.CultureInfo = new CultureInfo(Configue.Language.LanguageCode!);
        CultureInfo.CurrentUICulture = Language.CultureInfo;
    }
    public static void Changelanguage(string lang)
    {
        var code = Requete.GetCultureInfoCode(lang);

        Configue.Language.LanguageName = lang;
        Configue.Language.LanguageCode = code;

        Language.CultureInfo = new CultureInfo(code);
        CultureInfo.CurrentUICulture = Language.CultureInfo;

        //var cfs = new Strucs.StrucConfig.ConfigStruc();
        var cfs = new List<StrucConfig.ConfigStruc>
        {
            new() { Section = "Language", Key = "LanguageName", Value = lang },
            new() { Section = "Language", Key = "LanguageCode", Value = code }
            
        };
        
        foreach (var cf in cfs)
        {
            Requete.UpdateSettings(cf.Section!, cf.Key!, cf.Value!);
        }
        Connection.Transaction.Commit();
    }
}