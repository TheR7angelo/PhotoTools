﻿using System.Collections.Generic;
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
        foreach (var item in lines.Select((value, index) => new { index, value }))
        {
            WriteCsv(item.value, delimiter, writer, true);
            if(item.index < lines.Count() - 1) writer.Write(writer.NewLine);
        }
        writer.Close();
    }
    
    private static void WriteCsv(IEnumerable<object> lines, char delimiter, TextWriter writer, bool slave = false)
    {
        var iline = lines.Select(line => line.ToString()!).ToList();
        writer.Write(string.Join(delimiter, iline));
        
        if (!slave) writer.Close();
    }
}