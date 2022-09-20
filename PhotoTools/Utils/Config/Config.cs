using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using PhotoTools.Constant;
using PhotoTools.Utils.Sql;
using PhotoTools.Utils.Strucs;
using Query = PhotoTools.Utils.Sql.Query;

namespace PhotoTools.Utils.Config;

public static class Config
{
    public static StrucConfig.Configue Configue = new ();

    public static void InitializeApp()
    {
        Connection.InitializeBdds();
        var paramsStrucs = Query.GetParams();

        foreach (var param in paramsStrucs)
        {
            switch (param.Section)
            {
                case StrucConfig.ConfigSection.Language.Section:
                    switch (param.Key)
                    {
                        case StrucConfig.ConfigSection.Language.LanguageName:
                            Configue.Language.LanguageName = param.Value;
                            break;
                        case StrucConfig.ConfigSection.Language.LanguageCode:
                            Configue.Language.LanguageCode = param.Value;
                            break;
                    }
                    break;
                case StrucConfig.ConfigSection.Theme.Section:
                    Configue.Theme.Name = param.Value;
                    break;
                case StrucConfig.ConfigSection.ScreenSize.Section:
                    var screenSize = double.Parse(param.Value!);
                    switch (param.Key)
                    {
                        case StrucConfig.ConfigSection.ScreenSize.MinWidth:
                            Configue.ScreenSize.MinWidth = screenSize;
                            break;
                        case StrucConfig.ConfigSection.ScreenSize.MinHeight:
                            Configue.ScreenSize.MinHeight = screenSize;
                            break;
                    }
                    break;
            }
        }

        Language.CultureInfo = new CultureInfo(Configue.Language.LanguageCode!);
        CultureInfo.CurrentUICulture = Language.CultureInfo;
    }

    public static void InitializeStyle()
    {
        var styles = Query.GetActualStyle();
        foreach (var st in styles.Value)
        {
            Application.Current.Resources[st.Name] = st.StyleValue;
        }
    }
    public static void Changelanguage(string lang)
    {
        var code = Query.GetCultureInfoCode(lang);

        Configue.Language.LanguageName = lang;
        Configue.Language.LanguageCode = code;

        Language.CultureInfo = new CultureInfo(code);
        CultureInfo.CurrentUICulture = Language.CultureInfo;

        //var cfs = new Strucs.StrucConfig.ConfigStruc();
        var cfs = new List<StrucConfig.ConfigStruc>
        {
            new() { Section = StrucConfig.ConfigSection.Language.Section, Key = StrucConfig.ConfigSection.Language.LanguageName, Value = lang },
            new() { Section = StrucConfig.ConfigSection.Language.Section, Key = StrucConfig.ConfigSection.Language.LanguageCode, Value = code }
        };
        Connection.Transaction = Connection.Conn.BeginTransaction();
        foreach (var cf in cfs)
        {
            Query.UpdateSettings(cf.Section!, cf.Key!, cf.Value!);
        }
        Connection.Transaction.Commit();
    }
}