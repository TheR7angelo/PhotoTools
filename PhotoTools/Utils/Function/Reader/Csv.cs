using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhotoTools.Utils.Function.Reader;

public static partial class Reader
{
    public static List<List<string>> ReadCsv(this string filePath, char delimiter)
    {
        var csv = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        var sr = new StreamReader(csv);

        var lines = new List<string>();
        while (!sr.EndOfStream)
        {
            lines.Add(sr.ReadLine()!);
        }

        return lines.Select(line => line.Split(delimiter).ToList()).ToList();
    }
}