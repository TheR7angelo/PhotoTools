﻿using System;
using System.Data.SQLite;
using System.IO;

namespace PhotoTools.Sql;

public static partial class Requete
{
    private static string _AttachBdd(string path)
    {
        var filename = Path.GetFileName(path).Split(".")[0].ToLower();
        return $"ATTACH DATABASE '{path}' as {filename}";
    }

    private static string _GetParams()
    {
        return "SELECT pa.* FROM main.v_params pa ORDER BY pa.section";
    }

    private static string _GetAllLangs(string lang)
    {
        return $"SELECT la.{lang.ToLower()} FROM language.t_lang la ORDER BY la.{lang.ToLower()}";
    }
    private static string _GetCultureInfoLang(string code)
    {
        return $"SELECT cu.* FROM language.v_culture cu WHERE cu.code='{code}'";
    }
    private static string _GetCultureInfoCode(string lang)
    {
        return $"SELECT cu.* FROM language.v_culture cu WHERE cu.lang='{lang}'";
    }
    private static string _UpdateSettings(string section, string key, string value)
    {
        return $"""
                UPDATE main.t_params
                SET value = '{value}'
                WHERE key = '{key}'
                    AND fk_section = (SELECT id FROM main.t_section WHERE section = '{section}')
                """ ;
    }

    private static void Execute(string cmd)
    {
        new SQLiteCommand(cmd, Connection.Conn).ExecuteNonQuery();
    }
    private static SQLiteDataReader ExecuteReader(string cmd)
    {
        return new SQLiteCommand(cmd, Connection.Conn).ExecuteReader();
    }
}