using System;

namespace PhotoTools.Utils.Function;

public static partial class Convert
{

    #region bool

    public static bool ParseToBool(this string str)
    {
        return str.ParseToInt() > 0;
    }
    
    public static bool ParseToBool(this int i)
    {
        return i > 0;
    }

    #endregion

    #region int

    public static int ParseToInt(this string str)
    {
        if (int.TryParse(str, out _))
        {
            return int.Parse(str);
        }
        throw new InvalidOperationException("cannot parse to int");
    }

    public static int ParseToInt(this bool bo)
    {
        return bo ? 1 : 0;
    }

    #endregion
}