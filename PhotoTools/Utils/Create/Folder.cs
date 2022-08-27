using System;

namespace PhotoTools.Utils.Create;

public static class Folder
{
    public static void Main(int year)
    {
        for (var i=1; i<=12; i++)
        {
            var cultureInfo = Constant.Constant.CultureInfo;
            var date = new DateOnly(year, i, 1);

            var num = date.ToString("MM", cultureInfo);
            var month = date.ToString("MMMM", cultureInfo).Capitalize();
            Console.WriteLine($"{num}_{month}");
        }
    }
}