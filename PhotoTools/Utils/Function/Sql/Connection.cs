using System.Collections.Generic;
using System.Data.SQLite;

namespace PhotoTools.Utils.Function.Sql;

public static class Connection
{
    public static SQLiteConnection Conn { get; } = new (Constant.BasePath.BaseMain);
    public static SQLiteTransaction Transaction { get; set; } = null!;
    private static readonly List<string> PathBdds = new() { Constant.BasePath.BaseLanguage, Constant.BasePath.BaseProgress,};

    public static void InitializeBdds()
    {
        Conn.Open();
        Query.AttachBdds(PathBdds);
    }

    public static void CloseBdds()
    {
        Conn.Close();
    }
}