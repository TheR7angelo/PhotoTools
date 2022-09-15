using System;
using System.Collections.Generic;
using System.Windows.Media;
namespace PhotoTools.Utils;

public static class Function
{
    /// <summary>
    /// Convert Color to hexadecimal value
    /// </summary>
    /// <param name="color">GYGYGYGYGYGYGYGYJGJYGJYGJG</param>
    /// <returns><see cref="string"/></returns>
    public static string ToHex(this Color color)
    {
        return $"#{color.A:X}{color.R:X}{color.G:X}{color.B:X}";
    }
    /// <summary>
    /// Convert SolidColorBrush to hexadecimal value
    /// </summary>
    /// <param name="solidColorBrush">HGHFHGF</param>
    /// <returns><see cref="string"/></returns>
    public static string ToHex(this SolidColorBrush solidColorBrush)
    {
        return $"#{solidColorBrush.Color.A:X}{solidColorBrush.Color.R:X}{solidColorBrush.Color.G:X}{solidColorBrush.Color.B:X}";
    }
    public static SolidColorBrush SolidColorBrushConvert(string code)
    {
        return (SolidColorBrush)new BrushConverter().ConvertFromString(code)!;
    }
    public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
    {
        for(var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }
    public static string Capitalize(this string str)
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