using System.Data.SQLite;

namespace PhotoTools.Sql;

public static partial class Requete
{
    private static string _GetCultureInfoLang(string code)
    {
        return $"SELECT cu.* FROM v_culture cu WHERE cu.code='{code}'";
    }
    private static string _GetCultureInfoCode(string lang)
    {
        return $"SELECT cu.* FROM v_culture cu WHERE cu.lang='{lang}'";
    }

    private static SQLiteDataReader Execute(string cmd, SQLiteConnection conn)
    {
        var commande = new SQLiteCommand(cmd, conn);
        return commande.ExecuteReader();
    }
}