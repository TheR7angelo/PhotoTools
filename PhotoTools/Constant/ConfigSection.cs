namespace PhotoTools.Constant;

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