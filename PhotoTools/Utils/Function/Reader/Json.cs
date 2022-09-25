using System.IO;

namespace PhotoTools.Utils.Function.Reader;

public static partial class Reader
{
    public static string ReadJson(this string path) => File.ReadAllText(path);
}