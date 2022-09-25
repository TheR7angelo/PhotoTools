using System.Collections.Generic;
using System.Linq;

namespace PhotoTools.Utils.Function;

public static partial class Convert
{
    public static IEnumerable<Dictionary<string, string>> ParseToDictCsv(this List<List<string>> lines)
    {
        var result = new List<Dictionary<string, string>>();
        var columns = new List<string>();
        foreach (var line in lines.Select((value, index) => new { index, value }))
        {
            if (line.index.Equals(0))
            {
                columns = line.value;
                continue;
            }

            var dic = columns.Zip(line.value).ToDictionary(x => x.First, x => x.Second);
            result.Add(dic);
        }
        
        return result;
    }
}