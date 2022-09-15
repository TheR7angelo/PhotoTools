using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using PhotoTools.Utils;
using PhotoTools.Utils.Config;
using PhotoTools.Utils.Sql;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Sql;

public static partial class Query
{
    private static string _AttachBdd(string path)
    {
        var filename = Path.GetFileName(path).Split(".")[0].ToLower();
        return $"ATTACH DATABASE '{path}' as {filename}";
    }

    private static string _GetThemeExist(string name)
    {
        return $"SELECT name FROM main.t_style WHERE name='{name}'";
    }
    private static string _AddTheme(StrucConfig.Themes theme)
    {
        var listCol = new List<string>();
        var listVal = new List<string>();

        foreach (var th in theme.Value)
        {
            listCol.Add(th.Name);
            listVal.Add($"'{th.StyleValue.Color.ToHex()}'");
        }
        return $"INSERT INTO t_style (name, {string.Join(", ", listCol)}) VALUES ('{theme.Name}', {string.Join(", ", listVal)})";
    }
    
    private static string _GetStyle(string theme)
    {
        return $"SELECT * FROM main.t_style WHERE name='{theme}'";
    }

    private static string _GetAllStyles()
    {
        return "SELECT * FROM main.t_style ORDER BY name";
    }
    private static string _GetActualStyle()
    {
        return """
        SELECT st.*
        FROM main.t_style st
        WHERE st.name = (SELECT pa.value FROM main.v_params pa WHERE pa.section = 'Theme' AND pa.key = 'Name')
        """;
    }
    private static string _GetParams()
    {
        return "SELECT pa.* FROM main.v_params pa ORDER BY pa.section";
    }

    private static string _GetEnglishLang(string lang)
    {
        return $"""
                SELECT la.english
                FROM language.t_lang la
                WHERE la.{ Config.Configue.Language.LanguageName!.ToLower()}='{lang}'
                """;
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
        return $"SELECT cu.* FROM language.v_culture cu WHERE cu.english='{lang}'";
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