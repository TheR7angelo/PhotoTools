using System;
using System.Collections.Generic;
using System.IO;
using PhotoTools.Utils.Strucs;
using Newtonsoft.Json;

namespace PhotoTools.Utils.Function;

public partial class Export
{
    public static bool ExportJson(this string path, StrucConfig.Themes themes)
    {
        var data = new Dictionary<object, object> { { "name", themes.Name! } };

        foreach (var co in themes.Value)
        {
            data.Add(co.Name, co.StyleValue);
        }

        try
        {
            SaveJson(path, data);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static void SaveJson(this string path, Dictionary<object, object> data)
    {
        using var file = File.CreateText(path);
        var serializer = new JsonSerializer { Formatting = Formatting.Indented};
        serializer.Serialize(file, data);
    }
}