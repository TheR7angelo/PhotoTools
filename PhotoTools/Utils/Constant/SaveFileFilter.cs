namespace PhotoTools.Utils.Constant;

public static class SaveFileFilter
{
    // todo change string by trad
    public static Filter SemiColonCsv => new()
        { Value = "Csv (délimiter par des points virgule) (*.csv)|*.csv", Extension = ".csv" };

    public static Filter CommaCsv => new()
        { Value = "Csv (délimiter par une virgule) (*.csv)|*.csv", Extension = ".csv" };
    
    public static Filter Json => new () { Value = "Json file (*.json)|*.json", Extension = ".json" };
    
    public struct Filter
    {
        public string Value = string.Empty;
        public string Extension = string.Empty;

        public Filter(){}
    }
}