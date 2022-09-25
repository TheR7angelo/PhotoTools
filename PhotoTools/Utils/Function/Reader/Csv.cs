using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoTools.Utils.Function.Reader;

public static partial class Reader
{
    public static List<List<string>> ReadCsv(this string filePath, char delimiter)
    {
        // todo a tester
        var lines = File.ReadAllLines(filePath);

        return lines.Select(line => line.Split(delimiter).ToList()).ToList();
    }
}