namespace PhotoTools.Utils.Strucs;

public static class StrucConfig
{
    public struct Configue
    {
        public string? Theme;
        public ConfigLang Language = new();
        public ConfigScreenSize ScreenSize = new();

        public Configue()
        {
            Theme = string.Empty;
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
            public const string theme = "Theme";
        }
        public readonly struct ScreenSize
        {
            public const string Section = "ScreenSize";
            public const string MinWidth = "MinWidth";
            public const string MinHeight = "MinHeight";
        }
    }
}