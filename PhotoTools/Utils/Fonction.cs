using System;
using System.Globalization;
using PhotoTools.Sql;

namespace PhotoTools.Utils;

public static class Fonction
{
    public static void Changelanguage(string lang="English")
    {
        var code = Requete.GetCultureInfoCode(lang);
        
        Constant.Constant.LanguageName = lang;
        Constant.Constant.LanguageCode = code;

        Constant.Constant.CultureInfo = new CultureInfo(code);

    }
    public static string Capitalize(this  string str)
    {
        if (str.Length == 1){
            str = char.ToUpper(str[0]).ToString();
        }
        else{
            str = char.ToUpper(str[0]) + str[1..];
        }
        return str;
    }
}