using PhotoTools.Utils.Function.Reader;
using PhotoTools.Utils.Strucs;
using PhotoTools.Utils;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static StrucConfig.Themes ThemeCsv(this string filePath, char delimiter)
    {
        var data = filePath.ReadCsv(delimiter);
        // var data2 = Convert.ParseToDictCsv(data);

        return new StrucConfig.Themes();
    }
}