namespace PhotoTools.Utils.Function;

public static partial class Convert
{
    public static string Capitalize(this string str)
    {
        if (str.Length == 1){
            str = char.ToUpper(str[0]).ToString();
        }
        else{
            str = char.ToUpper(str[0]) + str[1..];
        }
        return str;
    }

    public static string InsertString(this string original, int index, string insertStr)
    {
        var newStr = string.Empty;
        
        
        return newStr;
    }
}