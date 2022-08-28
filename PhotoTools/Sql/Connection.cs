using System.Collections.Generic;
using System.Data.SQLite;

namespace PhotoTools.Sql;

public class Connection
{
    public static SQLiteConnection ConnLang { get; }= new (Constant.BasePath.BaseLanguage);

    private static readonly List<SQLiteConnection> Bdds = new() {ConnLang};

    public static void InitializeBdds()
    {
        foreach (var bdd in Bdds)
        {
            bdd.Open();
        }
    }

    public static void CloseBdds()
    {
        foreach (var bdd in Bdds)
        {
            bdd.Close();
        }
    }
}