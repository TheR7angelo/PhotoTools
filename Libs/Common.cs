namespace Libs;

public static class Common
{
    public static string Capitalize(this string str)
        => char.ToUpper(str[0]) + str[1..];
    
    public static IEnumerable<DateTime> EachDay(this DateTime from, DateTime thru)
    {
        for(var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            yield return day;
    }
}