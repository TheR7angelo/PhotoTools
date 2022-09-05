﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Sql;

public static partial class Requete
{
    private static SQLiteCommand _commande = new ();

    public static StrucConfig.Style GetActualStyle()
    {
        var reader = ExecuteReader(_GetActualStyle());
        reader.Read();

        return new StrucConfig.Style()
        {
            RgbM1 = reader["rgb_m1"].ToString()!,
            RgbM2 = reader["rgb_m2"].ToString()!,
            RgbM3 = reader["rgb_m3"].ToString()!,
            RgbB1 = reader["rgb_b1"].ToString()!,
            RgbB2 = reader["rgb_b2"].ToString()!,
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
    public static void AttachBdds(List<string> pathBdds)
    {
        foreach (var path in pathBdds)
        {
            Execute(_AttachBdd(path));
        }
    }
}