namespace PhotoTools.Utils.Constant;

public static class SaveFileFilter
{
    public static Filter All => new()
        { Value = Trad.SaveFileFilter.SaveFileFilter.All, Extension = FileExtension.All};
    
    public static Filter SemiColonCsv => new()
        { Value = Trad.SaveFileFilter.SaveFileFilter.SeminColonCsv, Extension = FileExtension.Csv };

    public static Filter CommaCsv => new()
        { Value = Trad.SaveFileFilter.SaveFileFilter.CommaCsv, Extension = FileExtension.Csv };
    
    public static Filter Json => new ()
        { Value = Trad.SaveFileFilter.SaveFileFilter.Json, Extension = FileExtension.Json };
    
    public struct Filter
    {
        public string Value = string.Empty;
        public string Extension = string.Empty;

        public Filter(){}
    }
}