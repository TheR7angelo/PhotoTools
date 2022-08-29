using System;
using System.Data.SQLite;

namespace PhotoTools.Sql;

public static partial class Requete
{
    private static SQLiteCommand _commande = new ();
    public static string? GetCultureInfoLang(string code)
    {
        var reader = Execute(_GetCultureInfoLang(code), Connection.ConnLang);

        reader.Read();
        var lang = reader["lang"].ToString();
        reader.Close();
        return lang;
    }
    public static string GetCultureInfoCode(string lang)
    {
        var reader = Execute(_GetCultureInfoCode(lang), Connection.ConnLang);

        reader.Read();
        var code = reader["code"].ToString();
        reader.Close();
        return code ?? throw new InvalidOperationException();
    }
}