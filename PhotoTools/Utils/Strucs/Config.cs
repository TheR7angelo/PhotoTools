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
}