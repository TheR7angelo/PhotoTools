using System.Globalization;

namespace Libs.Folder;

public static class Create
{
    public static async Task CreateFolder(this string parentFolder, int year, IEnumerable<string> middleFolder, CancellationToken token)
    {
        await Parallel.ForEachAsync(middleFolder, token, async (folder, _) =>
        {
            await Path.Join(parentFolder, year.ToString(), folder).CreateFolder(year);
        });
    }

    public static async Task CreateFolder(this string pathParent, int year)
    {
        var start = new DateTime(year, 1, 1);
        var stop = new DateTime(year + 1, 1, 1).AddDays(-1) ;
    
        await Parallel.ForEachAsync(start.EachDay(stop), (dateTime, _) 
            => dateTime.CreateFolder(pathParent));
    }

    private static ValueTask CreateFolder(this DateTime dateTime, string parentFolder)
    {
        var numMonth = dateTime.ToString("MM");
        var month = dateTime.ToString("MMMM", CultureInfo.CurrentCulture).Capitalize();

        var numDay = dateTime.ToString("dd");
        var day = dateTime.ToString("dddd", CultureInfo.CurrentCulture).Capitalize();

        var path = Path.Join(parentFolder, $"{numMonth}_{month}", $"{numDay}_{day}");
        Directory.CreateDirectory(path);
        
        return default;
    }
}