using PhotoTools.Utils.Function.Reader;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static StrucConfig.Themes ThemeCsv(this string filePath, char delimiter)
    {
        var i = new StrucConfig.Themes();
        var data = filePath.ReadCsv(delimiter).ParseToDictCsv();
        foreach (var dictionary in data)
        {
            return dictionary.ParseDictToTheme();
        }
        
        return i;
    }
}