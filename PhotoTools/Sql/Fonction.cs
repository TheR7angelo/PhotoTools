using System;
using System.Collections.Generic;
using PhotoTools.Utils;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Sql;

public static partial class Requete
{
    public static IEnumerable<StrucConfig.Themes> GetAllThemes()
    {
        var themes = new List<StrucConfig.Themes>();
        var reader = ExecuteReader(_GetAllThemes());
        while (reader.Read())
        {
            var th = new StrucConfig.Themes();
            th.Lock = Convert.ToBoolean((int)reader["lock"]);
            th.Name = reader["name"].ToString()!;
            themes.Add(th);
        }

        return themes;
    }
    public static IEnumerable<StrucConfig.StyleColorBrush> GetActualStyle()
    {
        var reader = ExecuteReader(_GetActualStyle());
        reader.Read();

        return new List<StrucConfig.StyleColorBrush>
        {
            new() { Name = "RgbM1", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_m1"].ToString()!) },
            new() { Name = "RgbM2", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_m2"].ToString()!) },
            new() { Name = "RgbM3", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_m3"].ToString()!) },
            new() { Name = "RgbB1", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_b1"].ToString()!) },
            new() { Name = "RgbB2", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_b2"].ToString()!) },
            new() { Name = "RgbB3", StyleValue = Fonction.SolidColorBrushConvert(reader["rgb_b3"].ToString()!) },
        };
    }
    public static string GetEnglishLang(string lang)
    {
        var reader = ExecuteReader(_GetEnglishLang(lang));
        reader.Read();
        return reader["english"].ToString()!;
    }
    public static IEnumerable<string> GetAllLangs(string lang)
    {
        var langs = new List<string>();
        var reader = ExecuteReader(_GetAllLangs(lang));
        while (reader.Read())
        {
            langs.Add(reader[lang.ToLower()].ToString()!);
        }

        return langs;
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
    public static List<StrucConfig.ConfigStruc> GetParams()
    {
        var cnfs = new List<StrucConfig.ConfigStruc>();
        var reader = ExecuteReader(_GetParams());

        while (reader.Read())
        {
            cnfs.Add(new StrucConfig.ConfigStruc()
            {
                Section = reader["section"].ToString(),
                Key = reader["key"].ToString(),
                Value = reader["value"].ToString()
            });
        }
        return cnfs;
    }
    public static void AttachBdds(List<string> pathBdds)
    {
        foreach (var path in pathBdds)
        {
            Execute(_AttachBdd(path));
        }
    }
}