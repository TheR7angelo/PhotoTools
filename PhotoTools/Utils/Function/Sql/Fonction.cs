using System;
using System.Collections.Generic;
using System.Data;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Function.Sql;

public static partial class Query
{
    public static bool DeleteTheme(this string name)
    {
        try
        {
            Query.Execute(Query._DeleteTheme(name));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    public static bool GetThemeExist(string name)
    {
        var reader = Query.ExecuteReader(Query._GetThemeExist(name));
        reader.Read();
        return reader.HasRows;
    }
    public static bool AddTheme(StrucConfig.Themes th)
    {
        try
        {
            Query.Execute(Query._AddTheme(th));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        
    }
    public static StrucConfig.Themes GetStyle(string theme)
    {
        var reader = Query.ExecuteReader(Query._GetStyle(theme));
        reader.Read();
        return GetThemeValues(reader);
    }
    public static IEnumerable<StrucConfig.Themes> GetAllThemes()
    {
        var themes = new List<StrucConfig.Themes>();
        var reader = Query.ExecuteReader(Query._GetAllStyles());
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
            Lock = Convert.ParseToBool(reader["lock"].ToString()!),
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
        var reader = Query.ExecuteReader(Query._GetActualStyle());
        reader.Read();
        return GetThemeValues(reader);
    }
    public static string GetEnglishLang(string lang)
    {
        var reader = Query.ExecuteReader(Query._GetEnglishLang(lang));
        reader.Read();
        return reader["english"].ToString()!;
    }
    public static IEnumerable<string> GetAllLangs(string lang)
    {
        var languages = new List<string>();
        var reader = Query.ExecuteReader(Query._GetAllLangs(lang));
        while (reader.Read())
        {
            languages.Add(reader[lang.ToLower()].ToString()!);
        }
        return languages;
    }

    public static string GetActualcultureLang(string lang)
    {
        var reader = Query.ExecuteReader(Query._GetActualcultureLang(lang));
        reader.Read();
        return reader[lang.ToLower()].ToString()!;
    }
    public static string? GetCultureInfoLang(string code)
    {
        var reader = Query.ExecuteReader(Query._GetCultureInfoLang(code));

        reader.Read();
        var lang = reader["lang"].ToString();
        reader.Close();
        return lang;
    }
    public static string GetCultureInfoCode(string lang)
    {
        var reader = Query.ExecuteReader(Query._GetCultureInfoCode(lang));

        reader.Read();
        var code = reader["code"].ToString();
        reader.Close();
        return code ?? throw new InvalidOperationException();
    }

    public static void UpdateSettings(string section, string key, string value)
    {
        Query.Execute(Query._UpdateSettings(section, key, value));
    }
    public static List<StrucConfig.ConfigStruc> GetParams()
    {
        var cnfs = new List<StrucConfig.ConfigStruc>();
        var reader = Query.ExecuteReader(Query._GetParams());

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
            Query.Execute(Query._AttachBdd(path));
        }
    }
}