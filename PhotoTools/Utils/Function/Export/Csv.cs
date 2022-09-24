using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    public static void ExportCsv(string path, StrucConfig.Themes themes, char delimiter)
    {
        var columns = new List<string> { "name" };
        var colors = new List<string>{ themes.Name! };

        foreach (var color in themes.Value)
        {
            columns.Add(color.Name);
            colors.Add(color.StyleValue.ToString());
        }

        var csv = new List<List<string>>{ columns, colors };
        var writer =  new StreamWriter(path);

        WriteCsv(csv, delimiter, writer);
        
        writer.Close();
    }

    private static void WriteCsv(IEnumerable<IEnumerable<object>> lines, char delimiter, TextWriter writer)
    {
        // todo make new line ;)
        foreach (var line in lines)
        {
            WriteCsv(line, delimiter, writer);
        }
    }
    
    private static void WriteCsv(IEnumerable<object> lines, char delimiter, TextWriter writer)
    {
        var iline = lines.Select(line => line.ToString()!).ToList();
        writer.Write(string.Join(delimiter, iline));
    }
}