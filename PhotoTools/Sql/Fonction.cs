using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhotoTools.Sql;

public static partial class Requete
{
    private static SQLiteCommand _commande = new ();

    public static List<Utils.Strucs.StrucConfig.ConfigStruc> GetParams()
    {
        var cnfs = new List<Utils.Strucs.StrucConfig.ConfigStruc>();
        var reader = ExecuteReader(_GetParams());

        while (reader.Read())
        {
            cnfs.Add(new Utils.Strucs.StrucConfig.ConfigStruc()
            {
                Section = reader["section"].ToString(),
                Key = reader["key"].ToString(),
                Value = reader["value"].ToString()
            });
        }
        return cnfs;
    }
    public static string? GetCultureInfoLang(string code)
    {
        var reader = ExecuteReader(_GetCultureInfoLang(code));

        reader.Read();
        var lang = reader["lang"].ToString();
        reader.Close();
        return lang;
    }
    public static string GetCultureInfoCode(string lang)
    {
        var reader = ExecuteReader(_GetCultureInfoCode(lang));

        reader.Read();
        var code = reader["code"].ToString();
        reader.Close();
        return code ?? throw new InvalidOperationException();
    }

    public static void UpdateSettings(string section, string key, string value)
    {
        Execute(_UpdateSettings(section, key, value));
    }
    public static void AttachBdds(List<string> pathBdds)
    {
        foreach (var path in pathBdds)
        {
            Execute(_AttachBdd(path));
        }
    }
}