using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace PhotoTools.Sql;

public static class Requete
{
    private static SQLiteCommand _commande = new (); 
    
    public static string GetCultureInfoCode(string lang)
    {
        var reader = Execute(_GetCultureInfoCode(lang), Connection.ConnLang);

        reader.Read();
        var code = reader["code"].ToString();
        reader.Close();
        return code ?? throw new InvalidOperationException();
    }
    
    private static string _GetCultureInfoCode(string lang)
    {
        return $"SELECT cu.* FROM t_culture cu WHERE cu.lang='{lang}'";
    }
    
    private static SQLiteDataReader Execute(string cmd, SQLiteConnection conn)
    {
        var commande = new SQLiteCommand(cmd, conn);
        return commande.ExecuteReader();
    }
}