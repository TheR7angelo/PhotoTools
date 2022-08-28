using System;
using System.Globalization;
using PhotoTools.Sql;

namespace PhotoTools.Utils;

public static class Fonction
{
    public static string Capitalize(this  string str)
    {
        if (str.Length == 1){
            str = char.ToUpper(str[0]).ToString();
        }
        else{
            str = char.ToUpper(str[0]) + str[1..];
        }
        return str;
    }
}