using System.Windows.Media;

namespace PhotoTools.Utils.Function;

public static partial class Convert
{
    /// <summary>
    /// Convert Color to hexadecimal value
    /// </summary>
    /// <param name="color">GYGYGYGYGYGYGYGYJGJYGJYGJG</param>
    /// <returns><see cref="string"/></returns>
    public static string ToHex(this Color color)
    {
        return $"#{color.A:X}{color.R:X}{color.G:X}{color.B:X}";
    }
    /// <summary>
    /// Convert SolidColorBrush to hexadecimal value
    /// </summary>
    /// <param name="solidColorBrush">HGHFHGF</param>
    /// <returns><see cref="string"/></returns>
    public static string ToHex(this SolidColorBrush solidColorBrush)
    {
        return $"#{solidColorBrush.Color.A:X}{solidColorBrush.Color.R:X}{solidColorBrush.Color.G:X}{solidColorBrush.Color.B:X}";
    }
    public static SolidColorBrush SolidColorBrush(this string code)
    {
        return (SolidColorBrush)new BrushConverter().ConvertFromString(code)!;
    }
}