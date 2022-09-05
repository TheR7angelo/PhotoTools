namespace PhotoTools.Utils.Strucs;

public static class StrucConfig
{
    #region Style

    public struct Style
    {
        public static string RgbM1 = null!;
        public static string RgbM2 = null!;
        public static string RgbM3 = null!;
        public static string RgbB1 = null!;
        public static string RgbB2 = null!;
    }

    #endregion

    #region Config

    public struct Configue
    {
        public string? Name;
        public ConfigLang Language = new();
        public ConfigScreenSize ScreenSize = new();

        public Configue()
        {
            Name = string.Empty;
        }
    }
    public struct ConfigLang
    {
        public string? LanguageName;
        public string? LanguageCode;
    }
    public struct ConfigScreenSize
    {
        public double MinWidth;
        public double MinHeight;
    }
    public struct ConfigStruc
    {
        public string? Key;
        public string? Value;
        public string? Section;
    }
    public static class ConfigSection
    {
        public readonly struct Language
        {
            public const string Section = "Language";
            public const string LanguageCode = "LanguageCode";
            public const string LanguageName = "LanguageName";
        }

        public readonly struct Theme
        {
            public const string Section = "Theme";
            public const string Name = "Theme";
        }
        public readonly struct ScreenSize
        {
            public const string Section = "ScreenSize";
            public const string MinWidth = "MinWidth";
            public const string MinHeight = "MinHeight";
        }
    }

    #endregion
}