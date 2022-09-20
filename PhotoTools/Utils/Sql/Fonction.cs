using System;
using System.Collections.Generic;
using System.Data;
using PhotoTools.Utils.Strucs;
using Convert = PhotoTools.Utils.Function.Convert;

namespace PhotoTools.Utils.Sql;

public static partial class Query
{
    public static bool DeleteTheme(this string name)
    {
        try
        {
            Execute(_DeleteTheme(name));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    public static bool GetThemeExist(string name)
    {
        var reader = ExecuteReader(_GetThemeExist(name));
        reader.Read();
        return reader.HasRows;
    }
    public static bool AddTheme(StrucConfig.Themes th)
    {
        try
        {
            Execute(_AddTheme(th));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    public static StrucConfig.Themes GetStyle(string theme)
    {
        var reader = ExecuteReader(_GetStyle(theme));
        reader.Read();
        return GetThemeValues(reader);
    }
    public static IEnumerable<StrucConfig.Themes> GetAllThemes()
    {
        var themes = new List<StrucConfig.Themes>();
        var reader = ExecuteReader(_GetAllStyles());
        while (reader.Read())
        {
            themes.Add(GetThemeValues(reader));
        }
        return themes;
    }

    private static StrucConfig.Themes GetThemeValues(IDataRecord reader)
    {
        return new StrucConfig.Themes
        {
            Lock = System.Convert.ToBoolean(int.Parse(reader["lock"].ToString()!)),
            Name = reader["name"].ToString()!,
            Value = new List<StrucConfig.StyleColorBrush>
            {
                new() { Name = "RgbM1", StyleValue = Convert.SolidColorBrush(reader["rgb_m1"].ToString()!) },
                new() { Name = "RgbM2", StyleValue = Convert.SolidColorBrush(reader["rgb_m2"].ToString()!) },
                new() { Name = "RgbM3", StyleValue = Convert.SolidColorBrush(reader["rgb_m3"].ToString()!) },
                new() { Name = "RgbB1", StyleValue = Convert.SolidColorBrush(reader["rgb_b1"].ToString()!) },
                new() { Name = "RgbB2", StyleValue = Convert.SolidColorBrush(reader["rgb_b2"].ToString()!) },
                new() { Name = "RgbB3", StyleValue = Convert.SolidColorBrush(reader["rgb_b3"].ToString()!) }
            }
        };
    }

    public static StrucConfig.Themes GetActualStyle()
    {
        var reader = ExecuteReader(_GetActualStyle());
        reader.Read();
        return GetThemeValues(reader);
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

    public static string GetActualcultureLang(string lang)
    {
        Console.WriteLine(_GetActualcultureLang(lang));
        var reader = ExecuteReader(_GetActualcultureLang(lang));
        reader.Read();
        return reader[lang.ToLower()].ToString()!;
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