using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static StrucConfig.Themes Json(this string path)
    {
        var data = path.ReadJson().DeserializeJson();

        var th = new StrucConfig.Themes
        {
            Lock = false,
            Value = new List<StrucConfig.StyleColorBrush>()
        };

        foreach (var key in data.Keys)
        {
            switch (key)
            {
                case "name":
                    th.Name = data[key].ToString();
                    break;
                default:
                    th.Value.Add(new StrucConfig.StyleColorBrush
                    {
                        Name = key.ToString()!,
                        StyleValue = data[key].ToString()!.SolidColorBrush()
                    });
                    break;
            }
        }

        return th;
    }

    public static Dictionary<object, object> DeserializeJson(this string data)
    {
        return JsonConvert.DeserializeObject<Dictionary<object, object>>(data)!;
    }

private static string ReadJson(this string path) => File.ReadAllText(path);
}