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
    private static string _GetCultureInfoLang(string code)
    {
        return $"SELECT cu.* FROM language.v_culture cu WHERE cu.code='{code}'";
    }
    private static string _GetCultureInfoCode(string lang)
    {
        return $"SELECT cu.* FROM language.v_culture cu WHERE cu.lang='{lang}'";
    }

    private static void Execute(string cmd)
    {
        new SQLiteCommand(cmd, Connection.Conn).ExecuteNonQuery();
    }
    private static SQLiteDataReader ExecuteReader(string cmd)
    {
        var command = new SQLiteCommand(cmd, Connection.Conn);
        return command.ExecuteReader();
    }
}