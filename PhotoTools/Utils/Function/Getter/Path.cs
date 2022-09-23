using System;

namespace PhotoTools.Utils.Function;

public partial class Get
{
    public static string GetCurrentPath => Environment.CurrentDirectory;
    
    public static string GetDesktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    public static string GetDocuments => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
}