using System;

namespace PhotoTools.Utils.Create;

public static class Folder
{
    public static void CreateFolderMonth(int year, string pathParent)
    {
        for (var i=1; i<=12; i++)
        {
            var date = new DateOnly(year, i, 1);

            var num = date.ToString("MM");
            var month = date.ToString("MMMM", Constant.Language.CultureInfo).Capitalize();

            var path = $"{pathParent}\\{year}\\{num}_{month}";
            
            Console.WriteLine($"{num}_{month}");

            System.IO.Directory.CreateDirectory(path);
            CreateFolderDays(date, path);
        }
    }

    public static void CreateFolderDays(DateOnly date, string parentPath)
    {
        var endDate = date.Month + 1 == 13 ? new DateOnly(date.Year + 1, 1, 1).AddDays(-1) : new DateOnly(date.Year, date.Month + 1, 1).AddDays(-1);

        foreach (var day in Fonction.EachDay(date.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MinValue)))
        {
            var num = day.ToString("dd");
            var weekDay = day.ToString("dddd", Constant.Language.CultureInfo).Capitalize();

            var path = $"{parentPath}\\{num}_{weekDay}";
            System.IO.Directory.CreateDirectory(path);
        }

    }
}