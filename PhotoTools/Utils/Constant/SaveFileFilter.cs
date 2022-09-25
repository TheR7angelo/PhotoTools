namespace PhotoTools.Utils.Constant;

public static class SaveFileFilter
{
    public static Filter SemiColonCsv => new()
        { Value = Trad.SaveFileFilter.SaveFileFilter.SeminColonCsv, Extension = ".csv" };

    public static Filter CommaCsv => new()
        { Value = Trad.SaveFileFilter.SaveFileFilter.CommaCsv, Extension = ".csv" };
    
    public static Filter Json => new ()
        { Value = Trad.SaveFileFilter.SaveFileFilter.Json, Extension = ".json" };
    
    public struct Filter
    {
        public string Value = string.Empty;
        public string Extension = string.Empty;

        public Filter(){}
    }
}