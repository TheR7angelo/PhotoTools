using System.Collections.Generic;
using System.IO;
using PhotoTools.Utils.Strucs;
using Newtonsoft.Json;

namespace PhotoTools.Utils.Function;

public static partial class Export
{
    public static void ExportJson(string path, StrucConfig.Themes themes)
    {
        var data = new Dictionary<object, object> { { "name", themes.Name! } };

        foreach (var co in themes.Value)
        {
            data.Add(co.Name, co.StyleValue);
        }
        
        SaveJson(path, data);
    }

    private static void SaveJson(string path, Dictionary<object, object> data)
    {
        using var file = File.CreateText(path);
        var serializer = new JsonSerializer { Formatting = Formatting.Indented};
        serializer.Serialize(file, data);
    }
}