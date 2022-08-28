using System;
using System.Collections.Generic;
using System.Globalization;
using PhotoTools.Sql;

namespace PhotoTools.Utils;

public static class Fonction
{
    public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for(var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }
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