using System.Globalization;

namespace PhotoTools.Constant;

public static partial class Constant
{
    public static string LanguageName { get; set; } = "French";
    public static string LanguageCode { get; set; } = "fr-FR";
    

    public static CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentCulture;
    
}