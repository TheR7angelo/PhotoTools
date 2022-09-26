using System.Collections.Generic;
using Newtonsoft.Json;
using PhotoTools.Utils.Function.Reader;
using PhotoTools.Utils.Strucs;

namespace PhotoTools.Utils.Function;

public static partial class Import
{
    public static StrucConfig.Themes ThemeJson(this string filePath)
    {
        return filePath.ReadJson().DeserializeJson().ParseDictToTheme();
    }

    private static Dictionary<string, string> DeserializeJson(this string data)
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(data)!;
    }
}