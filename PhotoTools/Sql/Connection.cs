using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhotoTools.Sql;

public static class Connection
{
    public static SQLiteConnection Conn { get; }= new (Constant.BasePath.BaseMain);
    private static readonly List<string> PathBdds = new() { Constant.BasePath.BaseLanguage, Constant.BasePath.BaseProgress };

    public static void InitializeBdds()
    {
        Conn.Open();
        Requete.AttachBdds(PathBdds);
    }

    public static void CloseBdds()
    {
        Conn.Close();
    }
}